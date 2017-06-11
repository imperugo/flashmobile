using imperugo.corsi.flashmobile.services.Repositories.Documents;

namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IDeviceRepository : IRepositoryBase<Device>
	{
		Device AddDevice(string deviceIdentifier, string callerIdentifier);
	}
}