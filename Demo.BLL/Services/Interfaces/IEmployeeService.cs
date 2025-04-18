using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.EmployeeDto;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool whitTracking = false );

        EmployeeDetailsDto? GetEmployeeById(int id);
        int CreateEmployee(CreatedEmployeeDto employee);
        int UpdateEmployee(UpdatedEmployeeDto employee);
        bool DeleteEmployee(int id);


    }
}
