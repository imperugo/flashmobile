using System;

namespace imperugo.corsi.flashmobile.common.Requests.Messages
{
	public class AddMessageBaseRequest : RequestBase
	{
		public string Message { get; set; }
		public Guid ChatIdentifier { get; set; }
	}
}