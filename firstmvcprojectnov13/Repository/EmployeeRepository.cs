using firstmvcprojectnov13.Models;

namespace firstmvcprojectnov13.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static List<Employee> _employees=new List<Employee> ();

        static EmployeeRepository() // this is constructor // static constructor is created for http forgetful behaviour solution
        {
           Employee objEmployee1= new Employee(); // this is employee class we have created in the model

           objEmployee1.Id = 1;
            objEmployee1.Name = "sailesh";
            objEmployee1.salary = 15000;
            objEmployee1.address = "harisiddhi";

            _employees.Add(objEmployee1);

            Employee objEmployee2= new Employee();

            objEmployee2.Id = 2;
            objEmployee2.Name = "Ashim";
            objEmployee2.salary = 10000;
            objEmployee2.address = "Thaiba";

            _employees.Add(objEmployee2);


            //another way of adding the employee in employee list

            _employees.Add(new Employee() { Id=3,Name="Sudan",salary=18000,address="Godawari"});

            _employees.Add(new Employee() { Id = 4, Name = "Samir", salary = 14000, address = "Imadol" });
        }

        public void CreateEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _employees.First(item => item.Id == id);
            _employees.Remove(employee); //here employee is the local variable of Employee class (this calss is made in model)
        }

        public Employee GetEmployeebyId(int id)
        {
            //use LINQ (language integrated query)
            Employee employee =_employees.First(item=> item.Id == id); //from list first stored employee info bata first value which is Employee.Id fetch gareko ho
            return employee;   //employee variablw return gareko which has Employee return data type
        }

        public List<Employee> GetEmployees()
        {
          return _employees;
        }

        public void updateEmployee(Employee employee) // sql ma update table set =  gareko justai ho
        {
            Employee emp=_employees.First(item=>item.Id==employee.Id); // practice this syntax
             
           // emp.Id = employee.Id;               //updating the  list _employees
            emp.address = employee.address;     //          "
            emp.salary = employee.salary;       //          "
            emp.Name = employee.Name;           //          "

        }
    }
}
