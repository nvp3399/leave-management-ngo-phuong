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

        public Task<Employee> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExist(int id)
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
