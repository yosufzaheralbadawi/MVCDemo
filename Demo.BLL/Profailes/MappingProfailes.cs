using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Profailes
{
    public class MappingProfailes : Profile
    {
        public MappingProfailes()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.EmpGender, options => options.MapFrom(src => src.Gender))
            .ForMember(dest => dest.EmpType, options => options.MapFrom(src => src.EmployeeType));

            CreateMap<Employee, EmployeeDetailsDto>()
        .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
        .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
        .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
