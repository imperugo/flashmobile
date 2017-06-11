using System;
using System.Collections.Concurrent;
using System.Linq;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Exceptions.Chats;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class ChatRepository : IChatRepository
	{
		public static ConcurrentBag<Chat> db = new ConcurrentBag<Chat>();

		public Chat CreateChat(string[] callerIndentifiers)
		{
			var chat = new Chat();
			chat.CallerIdentifiers = callerIndentifiers;
			chat.Id = Guid.NewGuid().ToString();

			db.Add(chat);

			return chat;
		}

		public void DeleteChat(string chatIdentifier)
		{
			var chat = db.FirstOrDefault(x => x.Id == chatIdentifier);

			if (chat == null)
				throw new ChatNotFoundException();

			var deleted = db.TryTake(out chat);

			if (!deleted)
				throw new ApplicationException("Something went wrong");
		}

		public void UpdateChat(string chatIdentifier, string name, string description, string avatarFilename)
		{
			var dbChat = db.FirstOrDefault(x => x.Id == chatIdentifier);

			if (dbChat == null)
				throw new ChatNotFoundException();

			dbChat.Name = name;
			dbChat.Description = description;
			dbChat.AvatarFileName = avatarFilename;
		}
	}
}