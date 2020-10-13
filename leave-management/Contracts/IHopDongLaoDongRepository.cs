using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IHopDongLaoDongRepository : IRepositoryStringKeyBase<HopDongLaoDong> 
    {
         Task<IEnumerable<HopDongLaoDong>> FindByEmployeeChuTheId(string employeeId);
    }
}
