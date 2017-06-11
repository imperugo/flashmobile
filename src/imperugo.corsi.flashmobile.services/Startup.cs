using imperugo.corsi.flashmobile.services.Repositories.Implementations;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace imperugo.corsi.flashmobile.services
{
	public class Startup
	{
		private readonly IHostingEnvironment environment;
		private readonly ILoggerFactory loggerFactory;

		public Startup(IHostingEnvironment environment, ILoggerFactory loggerFactory)
		{
			this.environment = environment;
			this.loggerFactory = loggerFactory;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Configure logging
			if (environment.IsDevelopment())
			{
				loggerFactory.AddConsole();
				loggerFactory.AddDebug();

				// Adding only in case the app is not behind a reverse proxy like IIS, 
				// otherwise let's do it to the proxy webserver (IIS)
				services.AddResponseCompression();
			}


			services.AddSingleton<IDeviceRepository, DeviceRepository>();
			services.AddSingleton<IChatRepository, ChatRepository>();

			services.AddAntiforgery(options => { options.RequireSsl = true; });

			services				
				.AddMvc(options =>
				{
					// Default value 200;
					options.MaxModelValidationErrors = 50;
				})
				.AddJsonOptions(opt =>
				{
					opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
					opt.SerializerSettings.Converters.Add(new IsoDateTimeConverter
					{
						DateTimeFormat = "yyyy-MM-dd\\THH:mm:ss.fffK"
					});

					JsonConvert.DefaultSettings = () => opt.SerializerSettings;
				});
		}

		public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime)
		{
			if (environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				// Adding only in case the app is not behind a reverse proxy like IIS, 
				// otherwise let's do it to the proxy webserver (IIS)
				app.UseResponseCompression();
			}

			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = x => x.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=604800" // A week in seconds
			});
			
			lifetime.ApplicationStopping.Register(() =>
			{
				// Need to dispose something before to exit from the application?
				// Here is the right place
			});

			app.UseMvcWithDefaultRoute();
		}
	}
}
