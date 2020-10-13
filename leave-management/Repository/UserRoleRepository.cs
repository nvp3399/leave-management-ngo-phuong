using leave_management.Contracts;
using leave_management.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext db;

        public UserRoleRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(IdentityUserRole<string> entity)
        {
            await db.UserRoles.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(IdentityUserRole<string> entity)
        {
            db.UserRoles.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<IdentityUserRole<string>>> FindAll()
        {
            return await db.UserRoles.ToListAsync();
        }

       


        public Task<IdentityUserRole<string>> FindById(string id_string)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUserRole<string>> FindByRoleID(string roleId)
        {
            return await db.UserRoles.FirstOrDefaultAsync(q => q.RoleId == roleId);
        }

        public async Task<IdentityUserRole<string>> FindByRoleIdAndUserID(string roleId, string userId)
        {
            return await db.UserRoles.FirstOrDefaultAsync(q => q.RoleId == roleId && q.UserId == userId);
        }

        public async Task<IdentityUserRole<string>> FindByUserID(string userId)
        {
            return await db.UserRoles.FirstOrDefaultAsync(q => q.UserId == userId);
        }

        public async Task<string> FindRoleIdByUserID(string userId)
        {
            return (await db.UserRoles.FirstOrDefaultAsync(q => q.UserId == userId)).RoleId;
        }

        public async Task<string> FindUserIdByRoleID(string roleId)
        {
            return (await db.UserRoles.FirstOrDefaultAsync(q => q.RoleId == roleId)).UserId;
        }



        public Task<bool> isExist(string id_string)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Replace(IdentityUserRole<string> oldEntity, IdentityUserRole<string> newEntity)
        {
            var deleteSuccess = await Delete(oldEntity);
            var createSuccess = await Create(newEntity);

            return  (deleteSuccess && createSuccess);
        }

        public async Task<bool> Save()
        {
            var changes = await db.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(IdentityUserRole<string> entity)
        {
            throw new NotImplementedException();
        }
    }
}
