namespace imperugo.corsi.flashmobile.common.Requests.Chats
{
	public class RemoveContactFromChatRequest : RequestBase
	{
		public string ChatIdentifier { get; set; }
		public string CallerIndentifier { get; set; }
	}
}