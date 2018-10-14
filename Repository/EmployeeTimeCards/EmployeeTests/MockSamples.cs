using EmployeeDomain;
using EmployeeDomain.Custom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeTests
{
    [TestClass]
    public class MockSamples
    {
        [TestMethod]
        public void MockSample()
        {
            Mock<IRepository<Employee>> mock = 
                new Mock<IRepository<Employee>>();

            mock.Setup(m => m.FindById(5))
                .Returns(new Employee {Id = 5});

            IRepository<Employee> repository = mock.Object;
                      
            var employee = repository.FindById(5);

            Assert.IsTrue(employee.Id == 5);
        }


        



    }
}