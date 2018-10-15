using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeDomain;
using EmployeeTests.Extensions;
using EmployeeTests.Fakes;
using EmployeeTests.Fakes.EF;
using EmployeeWeb.Controllers;
using EmployeeWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers {

    public class EmployeeControllerTestBase {

        public EmployeeControllerTestBase() {
            _employeeData = EmployeeObjectMother.CreateEmployees()
                                                .ToList();
            _repository = new InMemoryObjectSet<Employee>(_employeeData);
            _unitOfWork = new InMemoryUnitOfWork();
            _unitOfWork.Employees = _repository;
            _controller = new EmployeeController(_unitOfWork);
        }

        protected IList<Employee> _employeeData;
        protected EmployeeController _controller;
        protected InMemoryObjectSet<Employee> _repository;
        protected InMemoryUnitOfWork _unitOfWork;
    }

    [TestClass]
    public class EmployeeControllerIndexActionTests
               : EmployeeControllerTestBase {

        [TestMethod]
        public void SearchFindsPoonam()
        {
            var result = _controller.Index("NAM");
            var model = result.ViewData.Model as IEnumerable<Employee>;
            Assert.IsTrue(model.Any(e => e.Name == "Poonam"));
        }


        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Index();

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldBuildModelWithAllEmployees() {
            var result = _controller.Index();
            var model = result.ViewData.Model
                          as IEnumerable<Employee>;

            Assert.IsTrue(model.Count() == _employeeData.Count);
        }

        [TestMethod]
        public void ShouldOrderModelByHiredateAscending() {

            var result = _controller.Index();
            var model = result.ViewData.Model
                         as IEnumerable<Employee>;

            Assert.IsTrue(model.SequenceEqual(
                           _employeeData.OrderBy(e => e.HireDate)));
        }
    }
    
    [TestClass]
    public class EmployeeControllerDetailsActionTests
               : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Details(1);

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldBuildModelWithCorrectEmployee() {
            var id = 1;
            var result = _controller.Details(id);
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(model.Id == id);
        }
    }


    [TestClass]
    public class EmployeeControllerCreateActionGetTests : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Create();

            Assert.IsTrue(result.ViewName == "");
        }
    }

    [TestClass]
    public class EmployeeControllerCreateActionPostTests
               : EmployeeControllerTestBase {

        // ... more tests

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
            Assert.IsTrue(_repository.Contains(_newEmployee));
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork() {
            _controller.Create(_newEmployee);
            Assert.IsTrue(_unitOfWork.Committed);
        }

        Employee _newEmployee = new Employee() {
            Name = "NEW EMPLOYEE",
            HireDate = new System.DateTime(2010, 1, 1)
        };
    }

    [TestClass]
    public class EmployeeControllerEditActionGetTests : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var id = 1;
            var result = _controller.Edit(id);

            Assert.IsTrue(result.ViewName == "");
        }
    }

    [TestClass]
    public class EmployeeControllerEditActionPostTests : EmployeeControllerTestBase {

        public EmployeeControllerEditActionPostTests() {
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

            Assert.IsTrue(object.ReferenceEquals(model,
                          _repository.Single(e => e.Id == _editId)));
        }

        [TestMethod]
        public void ShouldModifyEmployeeWithPostedValues() {

            var result = _controller.Edit(_editId, null) as ViewResult;
            var employee = _repository.Single(e => e.Id == _editId);

            Assert.IsTrue(employee.Name == _updatedEmployee.Name);
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork() {

            _controller.Edit(_editId, null);

            Assert.IsTrue(_unitOfWork.Committed);
        }

        int _editId = 2;
        Employee _updatedEmployee = new Employee() {
            Name = "UPDATED EMPLOYEE",
            HireDate = new DateTime(1969, 1, 1)

        };
    }

    [TestClass]
    public class EmployeeControllerSummaryActionTests
               : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldBuildModelWithCorrectEmployeesummary() {
            var id = 1;
            var result = _controller.Summary(id);
            var model = result.ViewData.Model as EmployeeSummaryViewModel;

            Assert.IsTrue(model.TotalTimeCards == 3);
        }

        // ...
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Summary(1);

            Assert.IsTrue(result.ViewName == "");
        }
    }

}