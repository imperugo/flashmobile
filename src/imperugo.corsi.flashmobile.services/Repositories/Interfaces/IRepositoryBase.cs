namespace imperugo.corsi.flashmobile.services.Repositories.Interfaces
{
	public interface IRepositoryBase<T>
	{
		T GetById(string id);
		void Seed();
		void Seed(T[] documents);
	}
}