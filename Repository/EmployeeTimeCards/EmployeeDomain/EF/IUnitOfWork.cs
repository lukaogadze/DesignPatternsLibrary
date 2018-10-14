using System.Data.Objects;

namespace EmployeeDomain.EF
{
    public interface IUnitOfWork
    {
        IObjectSet<Employee> Employees { get; }
        IObjectSet<TimeCard> TimeCards { get; }
        void Commit();
    }
}