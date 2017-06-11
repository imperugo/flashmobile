using System;
using System.ComponentModel.DataAnnotations;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddMessageBaseRequest : RequestBase
	{
		[Required]
		public string Message { get; set; }

		[Required]
		public string ChatIdentifier { get; set; }
	}
}