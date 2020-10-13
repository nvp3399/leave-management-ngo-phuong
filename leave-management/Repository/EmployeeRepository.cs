using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Data;
using leave_management.Contracts;
namespace leave_management.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> FindAll()
        {
            throw new NotImplementedException();
        }



        public async Task<Employee> FindById(string id_string)
        {
            throw new NotImplementedException();
        }



        public Task<bool> isExist(string id_string)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
