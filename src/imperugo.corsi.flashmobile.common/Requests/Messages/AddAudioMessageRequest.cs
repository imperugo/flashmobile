using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddAudioMessageRequest : AddMessageBaseRequest
	{
		[FileExtensions(Extensions = "mp3")]
		public IFormFile Media { get; set; }
	}
}