using System;
using System.Data.Objects;
using EmployeeDomain;
using EmployeeDomain.Simple;

namespace Employee.Tests.Fakes.Simple
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {        
        public IObjectSet<Employee> Employees
        {
            get { throw new NotImplementedException(); }
        }

        public IObjectSet<TimeCard> TimeCards
        {
            get { throw new NotImplementedException(); }
        }
    }
}