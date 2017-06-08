using System.Collections.Concurrent;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class DeviceRepository : IDeviceRepository
	{
		private static readonly ConcurrentDictionary<string, string> db = new ConcurrentDictionary<string, string>();

		public Device Get(string callerIdentifier)
		{
			var exist = db.ContainsKey(callerIdentifier);

			if (exist)
			{
				return new Device
				{
					CallerIdentifier = callerIdentifier,
					DeviceIdentifier = db[callerIdentifier]
				};
			}

			return null;
		}

		public void AddDevice(string deviceIdentifier, string callerIdentifier)
		{
			var exist = db.ContainsKey(callerIdentifier);

			if (!exist)
			{
				db.TryAdd(callerIdentifier, deviceIdentifier);
				return;
			}

			var identifier = db[callerIdentifier];


			if (identifier == deviceIdentifier)
				return;

			throw new CallerIdentifierAlreadyRegistered(identifier, callerIdentifier);
		}
	}
}