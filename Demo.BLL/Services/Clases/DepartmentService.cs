using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.DepartmentDtos;

using Demo.BLL.Factories;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositries.Classes;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;


namespace Demo.BLL.Services.Clases
{
    public class DepartmentService(IDepartmentRepostitory _departmentRepository) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            //var departmentsToReturn = departments.Select(D => new DepartmentDto()
            //{
            //    Id = D.Id,
            //    Name = D.Name,
            //    Description = D.Description,
            //    Code = D.Code,
            //    DataOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            //});
            //return departmentsToReturn;

            return departments.Select(D => D.ToDepartmentDto());

        }

        public DepartmentDetailsDto? GetDeparmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentDetailsDto();

        }
        
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var deprtment = departmentDto.ToEntity();
            return _departmentRepository.Add(deprtment);

        }

        public int UpDateDepartment(UpdateDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());

        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;
            }
        }

    }
}
