using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeDomain;
using EmployeeDomain.Custom;
using EmployeeTests.Extensions;
using EmployeeTests.Fakes;
using EmployeeWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeTests.Custom.Controllers {

    public class EmployeeControllerTestBase {
    
        public EmployeeControllerTestBase() {
            _employeeData = EmployeeObjectMother.CreateEmployees()
                                                .AsQueryable();
            _repository = new Mock<IRepository<Employee>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.Employees)
                       .Returns(_repository.Object);

            _controller = new WorkerController(_unitOfWork.Object);
        }

        protected IQueryable<Employee> _employeeData;
        protected Mock<IUnitOfWork> _unitOfWork;
        protected WorkerController _controller;
        protected Mock<IRepository<Employee>> _repository;
    }

    [TestClass]
    public class EmployeeControllerIndexActionTests
               : EmployeeControllerTestBase {
        public EmployeeControllerIndexActionTests() {
            
            _repository.Setup(r => r.FindAll())
                        .Returns(_employeeData);
        }

        [TestMethod]
        public void ShouldBuildModelWithAllEmployees()
        {
            // testing state
            var result = _controller.Index();
            var model = result.ViewData.Model
                          as IEnumerable<Employee>;

            Assert.IsTrue(model.Count() == _employeeData.Count());
        }

        [TestMethod]
        public void ShouldInvokeFindallOnRepository()
        {
            // testing interaction
            var result = _controller.Index();

            _repository.Verify(r => r.FindAll());
        }


        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Index();

            Assert.IsTrue(result.ViewName == "");
        }
    }

    [TestClass]
    public class EmployeeControllerDetailsActionTests
               : EmployeeControllerTestBase {
        

        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Details(_detailsId);

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldInvokeRepositoryToFindEmployee() {
            var result = _controller.Details(_detailsId);

            _repository.Verify(r => r.FindById(_detailsId));
        }

        int _detailsId = 1;
    }

    [TestClass]
    public class WorkerControllerCreateActionGetTests
               : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Create();

            Assert.IsTrue(result.ViewName == "");
        }
    }

    [TestClass]
    public class WorkerControllerCreateActionPostTests
               : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRedirectToIndexViewIfSuccessful() {
            var result = _controller.Create(_newEmployee) as RedirectToRouteResult;

            Assert.IsTrue(result.RouteValues["action"].ToString() == "Index");
        }

        [TestMethod]
        public void ShouldRenderDefaultViewIfModelstateInvalid() {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Create(_newEmployee) as ViewResult;
            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldUseNewEmployeeAsModelIfModelstateInvalid() {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Create(_newEmployee) as ViewResult;
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(object.ReferenceEquals(model, _newEmployee));
        }

        [TestMethod]
        public void ShouldAddNewEmployeeToRepository() {
            _controller.Create(_newEmployee);

            _repository.Verify(r => r.Add(_newEmployee));
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork() {

            _controller.Create(_newEmployee);

            _unitOfWork.Verify(u => u.Commit());
        }

        Employee _newEmployee = new Employee() {
            Name = "NEW EMPLOYEE",
            HireDate = new System.DateTime(2010, 1, 1)
        };
    }

    [TestClass]
    public class WorkerControllerEditActionGetTests
               : EmployeeControllerTestBase {
        public WorkerControllerEditActionGetTests() {
            _repository.Setup(r => r.FindById(_editId))
                       .Returns(_employeeData.First());
        }

        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Edit(_editId);

            Assert.IsTrue(result.ViewName == "");
        }

        private int _editId = 1;
    }

    [TestClass]
    public class WorkerControllerEditActionPostTests
               : EmployeeControllerTestBase {
        public WorkerControllerEditActionPostTests() {
            _repository.Setup(r => r.FindById(_editId))
                       .Returns(_originalEmployee);
            _controller.ControllerContext = new ControllerContext();
            _controller.ValueProvider = _updatedEmployee.ToFormCollection().ToValueProvider();
        }

        [TestMethod]
        public void ShouldRedirectToIndexViewIfSuccessful() {
            var result = _controller.Edit(_editId, null) as RedirectToRouteResult;
            Assert.IsTrue(result.RouteValues["action"].ToString() == "Index");
        }

        [TestMethod]
        public void ShouldRenderDefaultViewIfModelstateInvalid() {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Edit(_editId, null) as ViewResult;
            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldUseEditemployeeAsModelIfModelstateInvalid() {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Edit(_editId, null) as ViewResult;
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(object.ReferenceEquals(model, _originalEmployee));
        }

        [TestMethod]
        public void ShouldModifyEmployeeWithPostedValues() {
            var result = _controller.Edit(_editId, null) as ViewResult;

            Assert.IsTrue(_originalEmployee.Name == _updatedEmployee.Name);
            Assert.IsTrue(_originalEmployee.HireDate == _updatedEmployee.HireDate);
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork() {
            _controller.Edit(_editId, null);

            _unitOfWork.Verify(u => u.Commit());
        }

        int _editId = 2;

        private Employee _originalEmployee = new Employee() {
            Name = "Old value",
            HireDate = new DateTime(1959, 1, 1)
        };
        Employee _updatedEmployee = new Employee() {
            Name = "UPDATED EMPLOYEE",
            HireDate = new DateTime(1969, 1, 1)
        };
    }
}