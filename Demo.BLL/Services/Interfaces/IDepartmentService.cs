using Demo.BLL.DTO.DepartmentDtos;


namespace Demo.BLL.Services.Interfaces
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
