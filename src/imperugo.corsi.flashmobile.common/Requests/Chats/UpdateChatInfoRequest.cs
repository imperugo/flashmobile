using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Chats
{
	public class UpdateChatInfoRequest : RequestBase
	{
		public string ChatIdentifier { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		[FileExtensions(Extensions = "jpg,jpeg")]
		public IFormFile Avatar { get; set; }
	}
}