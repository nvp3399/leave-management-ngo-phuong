using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IUserRoleRepository : IRepositoryStringKeyBase<IdentityUserRole<string>>
    {
        public Task<IdentityUserRole<string>> FindByRoleIdAndUserID(string roleId, string userId);
        public Task<IdentityUserRole<string>> FindByRoleID(string roleId);
        public Task<IdentityUserRole<string>> FindByUserID(string userId);
        public Task<string> FindRoleIdByUserID( string userId);
        public Task<string> FindUserIdByRoleID( string roleId);

        public Task<bool> Replace(IdentityUserRole<string> oldEntity, IdentityUserRole<string> newEntity);
    }
}
