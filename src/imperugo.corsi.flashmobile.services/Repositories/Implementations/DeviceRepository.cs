using System;
using System.Collections.Concurrent;
using System.Linq;
using imperugo.corsi.flashmobile.services.Exceptions;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class DeviceRepository : IDeviceRepository
	{
		private static readonly ConcurrentBag<Device> db = new ConcurrentBag< Device>();

		public Device AddDevice(string deviceIdentifier, string callerIdentifier)
		{
			var dbDevice = db.FirstOrDefault(x => x.CallerIdentifier == callerIdentifier);

			if (dbDevice == null)
			{
				var device = new Device
				{
					CallerIdentifier = callerIdentifier,
					DeviceIdentifier = deviceIdentifier,
					Id = Guid.NewGuid().ToString()
				};

				db.Add(device);
				return device;
			}


			if (dbDevice.DeviceIdentifier == deviceIdentifier)
				return dbDevice;

			throw new CallerIdentifierAlreadyRegistered(dbDevice.DeviceIdentifier, callerIdentifier);
		}

		public Device GetById(string id)
		{
			return db.FirstOrDefault(x => x.CallerIdentifier == id);
		}

		public void Seed()
		{
		}

		public void Seed(Device[] documents)
		{
		}
	}
}