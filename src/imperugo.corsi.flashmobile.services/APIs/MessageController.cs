using System;
using System.IO;
using imperugo.corsi.flashmobile.common.Requests.Messages;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace imperugo.corsi.flashmobile.services.APIs
{
	[Route("api/[controller]/[action]")]
	public class MessageController : ApiControllerBase
	{
		private readonly IChatRepository chatRepository;
		private readonly IHostingEnvironment hostingEnvironment;
		private readonly ILogger<MessageController> logger;
		private readonly IMessageRepository messageRepository;


		public MessageController(ILogger<MessageController> logger, IMessageRepository messageRepository,
			IChatRepository chatRepository, IHostingEnvironment hostingEnvironment)
		{
			this.logger = logger;
			this.messageRepository = messageRepository;
			this.chatRepository = chatRepository;
			this.hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		public IActionResult Get(string id)
		{
			var chat = messageRepository.GetById(id);

			if (chat == null)
				return NotFound();

			return Ok(chat);
		}

		[HttpPost]
		public IActionResult AddTextMessage([FromForm] AddMessageBaseRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var message = messageRepository.AddMessage(request.Message, request.ChatIdentifier);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpPost]
		public IActionResult AddAudioMessage([FromForm] AddAudioMessageRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var normalizedFilename = $"{Guid.NewGuid()}.jpg";

			var file = request.Media;
			var filename = Path.Combine(hostingEnvironment.WebRootPath, Constants.Storage.Audio, normalizedFilename);

			using (var stream = System.IO.File.OpenWrite(filename))
			{
				file.CopyToAsync(stream);
			}

			var message = messageRepository.AddAudioMessage(request.Message, request.ChatIdentifier, normalizedFilename);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpPost]
		public IActionResult AddVideoMessage([FromForm] AddVideoMessageRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var normalizedFilename = $"{Guid.NewGuid()}.jpg";

			var file = request.Media;
			var filename = Path.Combine(hostingEnvironment.WebRootPath, Constants.Storage.Video, normalizedFilename);

			using (var stream = System.IO.File.OpenWrite(filename))
			{
				file.CopyToAsync(stream);
			}

			var message = messageRepository.AddVideoMessage(request.Message, request.ChatIdentifier, normalizedFilename);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpPost]
		public IActionResult AddImageMessage([FromForm] AddImageMessageRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var normalizedFilename = $"{Guid.NewGuid()}.jpg";

			var file = request.Media;
			var filename = Path.Combine(hostingEnvironment.WebRootPath, Constants.Storage.Images, normalizedFilename);

			using (var stream = System.IO.File.OpenWrite(filename))
			{
				file.CopyToAsync(stream);
			}

			var message = messageRepository.AddImageMessage(request.Message, request.ChatIdentifier, normalizedFilename);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpPost]
		public IActionResult AddLocationMessage([FromForm] AddContactMessageRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var normalizedFilename = $"{Guid.NewGuid()}.jpg";

			var file = request.Contact;
			var filename = Path.Combine(hostingEnvironment.WebRootPath, Constants.Storage.Contacts, normalizedFilename);

			using (var stream = System.IO.File.OpenWrite(filename))
			{
				file.CopyToAsync(stream);
			}

			var message = messageRepository.AddContactMessage(request.Message, request.ChatIdentifier, normalizedFilename,
				request.Firstname, request.Lastname);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpPost]
		public IActionResult AddContactMessage([FromForm] AddLocationMessageRequest request)
		{
			if (request == null)
				return BadRequest("Unable to locate the body request");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exist = chatRepository.Exist(request.ChatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			var message = messageRepository.AddLocationMessage(request.Message, request.ChatIdentifier, request.Latitude,
				request.Latitude);

			return Created(new Uri($"/api/message/get/{message.Id}", UriKind.Relative), message);
		}

		[HttpGet]
		public IActionResult GetMessages([FromQuery] string chatIdentifier, [FromQuery] DateTime beginTime)	
		{

			var exist = chatRepository.Exist(chatIdentifier);

			if (!exist)
				return BadRequest("Unable to locate the specified chat.");

			return Ok(this.messageRepository.GetMessages(chatIdentifier, beginTime));
		}
	}
}