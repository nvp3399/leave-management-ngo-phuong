using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface ILeaveTypeRepository :IRepositoryIntKeyBase<LeaveType>
    {
        Task<ICollection<LeaveType>> GetEmployeesByleaveType(int id);
    }
}
