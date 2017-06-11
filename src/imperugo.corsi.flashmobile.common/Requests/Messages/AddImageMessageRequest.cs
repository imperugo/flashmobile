using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddImageMessageRequest : AddMessageBaseRequest
	{
		[FileExtensions(Extensions = "jpg,jpeg")]
		public IFormFile Media { get; set; }
	}
}