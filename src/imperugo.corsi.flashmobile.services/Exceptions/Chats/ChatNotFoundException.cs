namespace imperugo.corsi.flashmobile.services.Exceptions.Chats
{
	public class ChatNotFoundException : ApplicationException
	{
		public ChatNotFoundException() : base ((string) "Unable to locate the specified chat.")
		{
		}

		public ChatNotFoundException(string message) : base(message)
		{
		}
	}
}