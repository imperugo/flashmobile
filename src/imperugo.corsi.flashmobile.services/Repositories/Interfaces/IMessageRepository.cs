using imperugo.corsi.flashmobile.services.Repositories.Documents;

namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IMessageRepository : IRepositoryBase<MessageBase>
	{
		TextMessage AddMessage(string text, string chatIdentifier);
		ImageMessage AddImageMessage(string text, string chatIdentifier, string imageFilename);
		VideoMessage AddVideoMessage(string text, string chatIdentifier, string imageFilename);
		AudioMessage AddAudioMessage(string text, string chatIdentifier, string imageFilename);
		LocationMessage AddLocationMessage(string text, string chatIdentifier, double latitude, double longitude);
		ContactMessage AddContactMessage(string text, string chatIdentifier, string imageFilename, string firstname, string lastname);
	}
}