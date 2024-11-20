using firstmvcprojectnov13.Models;
using firstmvcprojectnov13.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstmvcprojectnov13.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;         //  IEmployeeRepository (this interface) is parent ,  employeeRepository(this is class)   is child

        public EmployeeController(IEmployeeRepository employee_dependency_injection) // this is constructor with dependency injection concept
        {
            // _employeeRepository = new EmployeeRepository();  // Note : parent class can hold the child class object  and stored in it but not vice versa // format ma interface (parent)= new child class
            // NOTE: in real word this method is not used to create object by help of another class .we used dependency injection concept

            _employeeRepository=employee_dependency_injection;  //dependency injection .see in service .add in program.cs file


        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee>lstEmployee = _employeeRepository.GetEmployees();
            return View(lstEmployee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)

        {
            var employee = _employeeRepository.GetEmployeebyId(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)  // model name is given as all values of model is filled  here
        {
            try
            {
                _employeeRepository.CreateEmployee(collection);
                return RedirectToAction(nameof(Index)); // Note: http (bhulaad kaar hay http) send one request at a time then forget everything after that  due to which the whole operation starts from                                                       
                                                        // begining  and previous data is override (deleted/disapear ) so static constructor is required in EmployeeRepository class
            }
            catch
            {
                // Console.WriteLine("error in primary key assigning");
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeebyId(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                _employeeRepository.updateEmployee(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployeebyId(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
