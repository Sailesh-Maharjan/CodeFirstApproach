using firstmvcprojectnov13.Models;

namespace firstmvcprojectnov13.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();   

        public Employee GetEmployeebyId(int id);

        public void updateEmployee(Employee employee);

        public void CreateEmployee(Employee employee);

        public void DeleteEmployee(int id);

      
    }
}
