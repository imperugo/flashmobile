using System;
using imperugo.corsi.flashmobile.common.Requests.Registration;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace imperugo.corsi.flashmobile.services.APIs
{
	[Route("api/[controller]/[action]")]
	public class DeviceController : ControllerBase
	{
		private readonly IDeviceRepository deviceRepository;
		private readonly ILogger<DeviceController> logger;

		public DeviceController(IDeviceRepository deviceRepository, ILogger<DeviceController> logger)
		{
			this.deviceRepository = deviceRepository;
			this.logger = logger;
		}

		[HttpGet]
		public IActionResult Get(string id)
		{
			return Ok(this.deviceRepository.Get(id));
		}

		[HttpPost]
		public IActionResult Add([FromForm] AddDeviceRequest request)
		{
			if (request == null)
			{
				return BadRequest("Unable to locate the body request");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				this.deviceRepository.AddDevice(request.DeviceIdentifier, request.CallerIdentifier);
			}
			catch (ApplicationException ex)
			{
				this.logger.LogWarning(ex.Message);

				return Conflict(ex.Message);
			}

			// save the device

			return Created(new Uri($"/api/device/get/{request.CallerIdentifier}",UriKind.Relative), request);
		}
	}
}