using System;
using EmployeeDomain.Custom;

namespace EmployeeDomain
{
    public class TimeCard : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int Hours { get; set; }
        public virtual DateTime EffectiveDate { get; set; }        
    }
}   