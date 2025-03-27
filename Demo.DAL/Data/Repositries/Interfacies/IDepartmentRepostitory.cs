using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IDepartmentRepostitory
    {

        // Get All
        IEnumerable<Department> GetAll(bool withTracking);

        // Get By Id
        Department GetById(int id);

        // Update
        int Update(Department Entity);

        // Delete
        int Delete(Department Entity);

        // Insert
        int Add(Department Entity);

    }
}
