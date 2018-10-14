using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDomain;

namespace EmployeeTests.Fakes {
    public static class EmployeeObjectMother {

        public static IEnumerable<Employee> CreateEmployees() {
            
            yield return new Employee() { 
                Id = 1, Name = "Scott", HireDate = new DateTime(2002, 1, 1), 
                TimeCards = CreateTimeCards().ToList() 
            };
            
            yield return new Employee() { 
                Id = 2, Name = "Poonam", HireDate = new DateTime(2001, 1, 1), 
                TimeCards = CreateTimeCards().ToList() 
            };
            yield return new Employee() { 
                Id = 3, Name = null, HireDate = new DateTime(2008, 1, 1), 
                TimeCards = CreateTimeCards().ToList() 
            };
        }
        // ...
        public static IEnumerable<TimeCard> CreateTimeCards() {
            yield return new TimeCard() { Id = 1, EffectiveDate = new DateTime(2010, 1, 1), Hours = 40 };
            yield return new TimeCard() { Id = 1, EffectiveDate = new DateTime(2010, 1, 8), Hours = 40 };
            yield return new TimeCard() { Id = 1, EffectiveDate = new DateTime(2010, 1, 15), Hours = 40 };
        }
    }
}