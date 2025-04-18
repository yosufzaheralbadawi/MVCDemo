using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class EmployeeRespository(AppDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
