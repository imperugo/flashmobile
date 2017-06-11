using System;
using System.Collections.Concurrent;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class DeviceRepository : IDeviceRepository
	{
		private static readonly ConcurrentDictionary<string, Device> db = new ConcurrentDictionary<string, Device>();

		public Device Get(string callerIdentifier)
		{
			var exist = db.ContainsKey(callerIdentifier);

			if (exist)
			{
				return db[callerIdentifier];
			}

			return null;
		}

		public void AddDevice(string deviceIdentifier, string callerIdentifier)
		{
			var exist = db.ContainsKey(callerIdentifier);

			if (!exist)
			{
				var device = new Device
				{
					CallerIdentifier = callerIdentifier,
					DeviceIdentifier = deviceIdentifier,
					Id = Guid.NewGuid().ToString()
				};

				db.TryAdd(callerIdentifier, device);
				return;
			}

			var identifier = db[callerIdentifier];


			if (identifier.DeviceIdentifier == deviceIdentifier)
				return;

			throw new CallerIdentifierAlreadyRegistered(identifier.DeviceIdentifier, callerIdentifier);
		}
	}
}