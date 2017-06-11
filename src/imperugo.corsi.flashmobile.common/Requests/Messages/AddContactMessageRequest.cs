using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddContactMessageRequest : AddMessageBaseRequest
	{
		[FileExtensions(Extensions = "vcf")]
		public IFormFile Contact { get; set; }

		public string Firstname { get; set; }

		public string Lastname { get; set; }
	}
}