using firstmvcprojectnov13.Data;
using firstmvcprojectnov13.Models;

namespace firstmvcprojectnov13.Repository
{
    public class SqlEmployeeRepository : IEmployeeRepository

    {
        private readonly AppDbContext _Context;
        public SqlEmployeeRepository(AppDbContext Context)  // constructor  with dependency injection
        {
          _Context = Context;
        }

        public void CreateEmployee(Employee employee)
        {
             _Context.Employees.Add(employee);
             _Context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = _Context.Employees.First(item => item.Id == id);
            _Context.Employees.Remove(emp);
            _Context.SaveChanges();
        }

        public Employee GetEmployeebyId(int id)
        {
            Employee emp= _Context.Employees.First(item => item.Id == id); // var emp or Employee emp both can be used . see EmployeeRepository.cs for more clear idea
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return _Context.Employees.ToList();
        }

        public void updateEmployee(Employee employee)
        {
            Employee emp = _Context.Employees.First(item => item.Id == employee.Id); // practice this syntax

            //emp.Id = employee.Id;               //updating the  database set _employees
            emp.address = employee.address;     //          "
            emp.salary = employee.salary;       //          "
            emp.Name = employee.Name;

            _Context.Employees.Update(emp);
            _Context.SaveChanges();                 // if your are changing or working in database savechanges() in database is compulsory 
        }
    }
}
