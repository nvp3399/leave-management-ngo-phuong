using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace leave_management.Contracts
{
    public interface IRoleRepository : IRepositoryStringKeyBase<IdentityRole>
    {
       
    }
}
