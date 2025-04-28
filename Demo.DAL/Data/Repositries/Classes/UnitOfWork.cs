using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Data.Repositries.Interfacies;

namespace Demo.DAL.Data.Repositries.Classes
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepository _EmployeeRepository;
        private IDepartmentRepostitory _DepartmentRepostitory;
        private readonly AppDbContext _dbContext;

        public UnitOfWork( IDepartmentRepostitory departmentRepostitory, AppDbContext dbContext ,
            IEmployeeRepository employeeRepository)
        {
            _DepartmentRepostitory= departmentRepostitory;
            _dbContext = dbContext;
            _EmployeeRepository = employeeRepository;    
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _EmployeeRepository;
            }
            set
            {
                _EmployeeRepository = value;
            }
        }
        public IDepartmentRepostitory departmentRepostitory {
            get
            {
                return _DepartmentRepostitory;
            }
            set

            {
                _DepartmentRepostitory = value;
            }
        }

        public int SaveChanges()
        {
          return  _dbContext.SaveChanges();
        }
    }
}
