using imperugo.corsi.flashmobile.common.Requests.Chats;
using imperugo.corsi.flashmobile.services.Repositories.Documents;

namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IChatRepository
	{
		Chat GetById(string chatIdentifier);
		Chat CreateChat(string[] callerIndentifiers);
		void DeleteChat(string chatIdentifier);
		void UpdateChat(string chatIdentifier, string name, string description, string avatarFilename);
	}
}