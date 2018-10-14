using System;
using System.Collections.Generic;
using EmployeeDomain.Custom;

namespace EmployeeDomain
{
    public class Employee : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual ICollection<TimeCard> TimeCards { get; set; }
    }
}