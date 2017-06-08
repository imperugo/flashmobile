using System;

namespace imperugo.corsi.flashmobile.services.Exceptions
{
	public class CallerIdentifierAlreadyRegistered : ApplicationException
	{
		private readonly string oldDeviceIdentifier;
		private readonly string callerIdentifier;

		public CallerIdentifierAlreadyRegistered(string oldDeviceIdentifier, string callerIdentifier)
		{
			this.oldDeviceIdentifier = oldDeviceIdentifier;
			this.callerIdentifier = callerIdentifier;
		}

		public override string Message => $"Another device ({oldDeviceIdentifier}) is already registerd for the specified called ({callerIdentifier}).";
	}
}