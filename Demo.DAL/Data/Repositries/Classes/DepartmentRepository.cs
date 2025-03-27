using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    // primary constructor
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepostitory
    {

        private readonly AppDbContext _dbContext = dbContext; // null

        public int Add(Department Entity)
        {
            _dbContext.Departments.Add(Entity); // added
            return _dbContext.SaveChanges();    // update database
        }

       
        public int Delete(Department Entity)
        {
             _dbContext.Departments.Remove(Entity);
             return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department Entity)
        {
            _dbContext.Departments.Update(Entity);
            return _dbContext.SaveChanges();
        }
    }
}
