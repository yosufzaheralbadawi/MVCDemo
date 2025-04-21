using Demo.BLL.DTO.DepartmentDtos;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Clases;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models.EmployeeModel;
using Demo.PL.ViewModels;
using Demo.PL.ViewModels.EmployeeModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController (IEmployeeService _employeeService , ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var Employee = _employeeService.GetAllEmployees();
                return View(Employee);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeCreatedDto = new CreatedEmployeeDto()
                    {
                        Name = employeeDto.Name,
                        Address = employeeDto.Address,
                        Age = employeeDto.Age,
                        IsActive = employeeDto.IsActive,
                        Email = employeeDto.Email,
                        EmployeeType = employeeDto.EmployeeType,
                        Gender = employeeDto.Gender,
                        HiringDate = employeeDto.HiringDate,
                        PhoneNumber = employeeDto.PhoneNumber,
                        Salary = employeeDto.Salary,
                    };

                    int result = _employeeService.CreateEmployee(employeeCreatedDto);

                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can't be created !!");

                    }
                }
                catch (Exception ex)
                {
                    // Log exception
                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => Log Error in Console and return same view with error msg
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else
                    {
                        // 2. Deployment => Log Error: in file | Table in database and Return Error view
                        _logger.LogError(ex.Message);
                    }

                }

            }
            return View(employeeDto);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound(); // 404

            return View(employee);

        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeDto = new EmployeeViewModel()
            {
                
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            };

            return View(employeeDto);

        }

     

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                var employeeUpdatedDto = new UpdatedEmployeeDto()
                {
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    Age = viewModel.Age,
                    IsActive = viewModel.IsActive,
                    Email = viewModel.Email,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    HiringDate = viewModel.HiringDate,
                    PhoneNumber = viewModel.PhoneNumber,
                    Salary = viewModel.Salary,
                };
                int result = _employeeService.UpdateEmployee(employeeUpdatedDto);
                if (result > 0)
                {
                    TempData["Message"] = "Employee Created Succesfuly";
                    return RedirectToAction(nameof(Index));

                }

                else
                {
                    TempData["Message"] = "Employee Created Failed";
                    ModelState.AddModelError(string.Empty, "Employee can't be updated !!");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Log exception
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error in Console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                {
                    // 2. Deployment => Log Error: in file | Table in database and Return Error view
                    _logger.LogError(ex.Message);

                }

            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete ( int id )
        {
            if (id == 0) return BadRequest();
            try
            {
                var deleted = _employeeService.DeleteEmployee(id);
                if (deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Is Not Deleted!");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Log exception
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error in Console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                {
                    // 2. Deployment => Log Error: in file | Table in database and Return Error view
                    _logger.LogError(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }

        }

    }

}
 