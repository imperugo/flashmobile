using System.ComponentModel.DataAnnotations;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddLocationMessageRequest : AddMessageBaseRequest
	{
		[Required]
		public long Latitude { get; set; }

		[Required]
		public long Longitude { get; set; }
	}
}