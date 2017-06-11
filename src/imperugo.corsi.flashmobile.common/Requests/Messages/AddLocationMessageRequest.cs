namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddLocationMessageRequest : AddMessageBaseRequest
	{
		public long Latitude { get; set; }
		public long Longitude { get; set; }
	}
}