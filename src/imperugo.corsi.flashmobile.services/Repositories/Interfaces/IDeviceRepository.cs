using imperugo.corsi.flashmobile.services.Repositories.Documents;

namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IDeviceRepository
	{
		Device Get(string callerIdentifier);
		void AddDevice(string deviceIdentifier, string callerIdentifier);
	}
}