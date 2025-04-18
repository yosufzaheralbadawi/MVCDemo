using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models.DepartmentModels;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    // primary constructor
    public class DepartmentRepository(AppDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepostitory
    {

        
    }
}
