using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModels;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class GenericRepository<TEntity>(AppDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public int Add(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Add(Entity); // added
            return _dbContext.SaveChanges();    // update database
        }


        public int Delete(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Remove(Entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public int Update(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Update(Entity);
            return _dbContext.SaveChanges();
        }

        public void Updatetest()
        {
            
        }

    }
}
