using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Chats
{
	public class UpdateChatInfoRequest : RequestBase
	{
		[Required]
		public string ChatIdentifier { get; set; }
		
		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		public IFormFile Avatar { get; set; }
	}
}