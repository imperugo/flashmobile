namespace imperugo.corsi.flashmobile.services.Exceptions.Chats
{
	public class ChatAlreadyExistException : ApplicationException
	{
		public ChatAlreadyExistException() : base ("The specified chat already exists.")
		{
		}

		public ChatAlreadyExistException(string message) : base(message)
		{
		}
	}
}