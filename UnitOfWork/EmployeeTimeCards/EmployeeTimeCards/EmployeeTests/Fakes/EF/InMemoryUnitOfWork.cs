using System;
using System.Data.Objects;
using EmployeeDomain;
using EmployeeDomain.EF;

namespace EmployeeTests.Fakes.EF {
    public class InMemoryUnitOfWork : IUnitOfWork {

        public InMemoryUnitOfWork() {
            Committed = false;
        }

        public IObjectSet<Employee> Employees {
            get;
            set;
        }

        public IObjectSet<TimeCard> TimeCards {
            get;
            set;
        }

        public bool Committed { get; set; }

        public void Commit() {
            Committed = true;
        }
    }
}