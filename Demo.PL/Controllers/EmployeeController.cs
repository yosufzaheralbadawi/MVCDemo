using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositries.Interfacies;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController (IEmployeeService _employeeService) : Controller
    {
        public IActionResult Index()
        {
            var Employee = _employeeService.GetAllEmployees();
                return View(Employee);
        }
    }
}
