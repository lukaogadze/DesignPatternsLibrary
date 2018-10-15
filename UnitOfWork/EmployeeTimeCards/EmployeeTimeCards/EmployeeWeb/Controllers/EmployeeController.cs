using System.Linq;
using System.Web.Mvc;
using EmployeeData.EF;
using EmployeeData.Extensions;
using EmployeeDomain;
using EmployeeDomain.EF;
using EmployeeWeb.Models;

namespace EmployeeWeb.Controllers {
    // Using the IObjectSet<T> EF implementation
    public partial class EmployeeController : Controller {


        public EmployeeController()
            : this(new SqlUnitOfWork()) {

        }

        public EmployeeController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Employee/

        public ViewResult Index(string q = null) {
            var model = _unitOfWork.Employees
                                   .OrderBy(e => e.HireDate)                   
                                   .Include("TimeCards");
            if(!string.IsNullOrEmpty(q))
            {
                model = model.Where(e => e.Name.ToLower().Contains(q));
            }
            return View(model);
        }

        //
        // GET: /Employee/Details/5

        public ViewResult Details(int id){ 
            var employee = _unitOfWork.Employees
                                      .Single(e => e.Id == id);
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ViewResult Create() {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Employee newEmployee) {
            if (ModelState.IsValid) {
                _unitOfWork.Employees.AddObject(newEmployee);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(newEmployee);

        }

        //
        // GET: /Employee/Edit/5

        public ViewResult Edit(int id) {
            var model = _unitOfWork.Employees.Single(e => e.Id == id);
            return View(model);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            var model = _unitOfWork.Employees.Single(e => e.Id == id);
            TryUpdateModel(model, new string[] { "Name", "HireDate" });
            if (ModelState.IsValid) {
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /Employee/Summary/5

        public ViewResult Summary(int id) {
            var model = _unitOfWork.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeSummaryViewModel {
                    Name = e.Name,
                    TotalTimeCards = e.TimeCards.Count()
                })
                .First();

            return View(model);
        }

        IUnitOfWork _unitOfWork;
    }
}
