using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IRepositoryStringKeyBase<T>
        where T: class
    {
        Task<ICollection<T>> FindAll();
        Task<T> FindById(string id);
        Task<bool> isExist(string id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}
