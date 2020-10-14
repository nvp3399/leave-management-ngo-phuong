using leave_management.Data;
using leave_management.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IGiayToTuyThanRepository : IRepositoryStringKeyBase<GiayToTuyThan>
    {
         Task<bool> isExist(string employeeId, string maLoaiGiayTo);
    }
}
