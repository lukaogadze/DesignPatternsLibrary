using System;
using System.Linq;
using System.Web.Mvc;
using EmployeeData.Custom;
using EmployeeData.Extensions;
using EmployeeDomain;
using EmployeeDomain.Custom;

namespace EmployeeWeb.Controllers
{
    public class WorkerController : Controller
    {       
        public WorkerController()
            :this(new SqlUnitOfWork())
        {
            
        }

        public WorkerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Employees;
        }        

        public ViewResult Index()
        {
            var model = _repository.FindAll()                                   
                                   .OrderBy(e => e.HireDate);
            return View(model);
        }


        public ViewResult Details(int id)
        {
            var model = _repository.FindById(id);

            return View(model);
        }

       
        public ViewResult Create()
        {
            return View();
        } 
 

        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(newEmployee);                
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(newEmployee);
        }
        
      
        public ViewResult Edit(int id)
        {
            var model = _repository.Find(e => e.Id == id)
                                   .Single();
            return View(model);
        }
        

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = _repository.FindById(id);
            TryUpdateModel(model, new[] { "Name", "HireDate" });
            if (ModelState.IsValid)
            {
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _repository;
    }
}
