using Data.Entities;

namespace Business.Interfaces
{
    public interface IEmployeesService
    {
        EmployeesEntity CreateEmployees(EmployeesEntity employeesEntity);
        bool DeleteEmployees(int id);
        IEnumerable<EmployeesEntity> GetEmployees();
        EmployeesEntity GetEmployeesById(int id);
        EmployeesEntity UpdateEmployees(EmployeesEntity employeesEntity);
    }
}