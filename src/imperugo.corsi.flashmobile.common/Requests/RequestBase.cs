using System.ComponentModel.DataAnnotations;

namespace imperugo.corsi.flashmobile.common.Requests
{
	public class RequestBase
	{
		[Required]
		public string CallerIdentifier { get; set; }

		[Required]
		public string DeviceIdentifier { get; set; }
	}
}