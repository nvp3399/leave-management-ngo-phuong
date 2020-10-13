using leave_management.Contracts;
using leave_management.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace leave_management.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public Task<bool> Create(IdentityRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(IdentityRole entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<IdentityRole>> FindAll()
        {
            return await _db.Roles.ToListAsync();
        }


        public async Task<IdentityRole> FindById(string id_string)
        {

            return await _db.Roles.FirstOrDefaultAsync(q => q.Id == id_string);
        }



        public Task<bool> isExist(string id_string)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(IdentityRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
