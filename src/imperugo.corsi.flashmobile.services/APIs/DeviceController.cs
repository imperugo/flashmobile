using System;
using imperugo.corsi.flashmobile.common.Requests.Registration;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace imperugo.corsi.flashmobile.services.APIs
{
	[Route("api/[controller]/[action]")]
	public class DeviceController : ApiControllerBase
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
			var device = this.deviceRepository.GetById(id);

			if (device == null)
			{
				return NotFound();
			}

			return Ok(device);
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

			Device device = null;

			try
			{
				device = this.deviceRepository.AddDevice(request.DeviceIdentifier, request.CallerIdentifier);
			}
			catch (ApplicationException ex)
			{
				this.logger.LogWarning(ex.Message);

				return Conflict(ex.Message);
			}

			return Created(new Uri($"/api/device/get/{device.Id}",UriKind.Relative), device);
		}
	}
}