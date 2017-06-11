using System.Collections.Concurrent;
using System.Linq;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class MessageRepository : IMessageRepository
	{
		private static readonly ConcurrentBag<MessageBase> db = new ConcurrentBag<MessageBase>();

		public MessageBase GetById(string id)
		{
			return db.FirstOrDefault(x => x.Id == id);
		}

		public void Seed()
		{
		}

		public void Seed(MessageBase[] documents)
		{
		}
	}
}