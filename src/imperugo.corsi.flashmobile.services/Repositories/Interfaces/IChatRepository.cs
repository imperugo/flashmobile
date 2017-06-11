using imperugo.corsi.flashmobile.services.Repositories.Documents;

namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IChatRepository : IRepositoryBase<Chat>
	{
		Chat CreateChat(string[] callerIndentifiers);
		void DeleteChat(string chatIdentifier);
		void UpdateChat(string chatIdentifier, string name, string description, string avatarFilename);
	}
}