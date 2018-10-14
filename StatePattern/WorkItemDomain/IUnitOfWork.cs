namespace WorkItemDomain
{
	public interface IUnitOfWork
	{
		IRepository<IEntity> Entities { get; }
		void Commit();
	}
}