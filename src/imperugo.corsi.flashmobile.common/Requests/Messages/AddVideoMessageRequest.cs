using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddVideoMessageRequest : AddMessageBaseRequest
	{
		[Required]
		public IFormFile Media { get; set; }
	}
}