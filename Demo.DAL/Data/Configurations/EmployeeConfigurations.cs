using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configurations
{
    public class EmployeeConfigurations :BaseEntityConfigurations<Employee>,  IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");

            builder.Property(e => e.Gender)
                .HasConversion(
                    empGender => empGender.ToString(),
                    returnedEmpGender => (Gender)Enum.Parse(typeof(Gender), returnedEmpGender));

            builder.Property(e => e.EmployeeType)
                .HasConversion(
                    empType => empType.ToString(),
                    returnedEmpType => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnedEmpType));

            base.Configure(builder);
  
        }
    }
}
