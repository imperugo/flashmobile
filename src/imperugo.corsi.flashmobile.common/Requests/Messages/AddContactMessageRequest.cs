using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddContactMessageRequest : AddMessageBaseRequest
	{
		[Required]
		public IFormFile Contact { get; set; }

		[Required]
		public string Firstname { get; set; }

		[Required]
		public string Lastname { get; set; }
	}
}