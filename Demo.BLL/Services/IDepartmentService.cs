using Demo.BLL.DTO;

namespace Demo.BLL.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDeparmentById(int id);
        int UpDateDepartment(UpdateDepartmentDto departmentDto);
    }
}