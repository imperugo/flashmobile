using System;
using System.IO;
using imperugo.corsi.flashmobile.common.Requests.Chats;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace imperugo.corsi.flashmobile.services.APIs
{
	[Route("api/[controller]/[action]")]
	public class ChatController : ApiControllerBase
	{
		private readonly IChatRepository chatRepository;
		private readonly ILogger<ChatController> logger;
		private readonly IHostingEnvironment hostingEnvironment;

		public ChatController(ILogger<ChatController> logger, IChatRepository chatRepository, IHostingEnvironment hostingEnvironment)
		{
			this.logger = logger;
			this.chatRepository = chatRepository;
			this.hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		public IActionResult Get(string id)
		{
			var chat = this.chatRepository.GetById(id);

			if (chat == null)
			{
				return NotFound();
			}

			return Ok(chat);
		}

		[HttpPost]
		public IActionResult CreateChat([FromForm] CreateChatRequest request)
		{
			if (request == null)
			{
				return BadRequest("Unable to locate the body request");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var chat = this.chatRepository.CreateChat(request.CallerIndentifiers);

			return Created(new Uri($"/api/chat/get/{chat.Id}", UriKind.Relative), chat);
		}

		[HttpPut]
		public IActionResult UpdateChat([FromForm] UpdateChatInfoRequest request)
		{
			if (request == null)
			{
				return BadRequest("Unable to locate the body request");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			string normalizedFilename = $"{Guid.NewGuid()}.jpg";

			var file = request.Avatar;
			var filename = Path.Combine(hostingEnvironment.WebRootPath, "Constants.Storage.ChatAvatars", normalizedFilename);

			using (var stream = System.IO.File.OpenWrite(filename))
			{
				file.CopyToAsync(stream);
			}

			this.chatRepository.UpdateChat(request.CallerIdentifier,request.Name,request.Description, normalizedFilename);

			return Ok();
		}
	}
}