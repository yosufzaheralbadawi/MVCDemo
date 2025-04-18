using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        // Get All
        IEnumerable<TEntity> GetAll(bool withTracking = false);

        // Get By Id
        TEntity GetById(int id);

        // Update
        int Update(TEntity Entity);

        // Delete
        int Delete(TEntity Entity);

        // Insert
        int Add(TEntity Entity);
    }
}
