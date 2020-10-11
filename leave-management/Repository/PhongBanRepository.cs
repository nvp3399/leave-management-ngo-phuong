using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    public class PhongBanRepository : IPhongBanRepository
    {
        private readonly ApplicationDbContext _db;

        public PhongBanRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<bool> Create(DanhMucPhongBan entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(DanhMucPhongBan entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DanhMucPhongBan>> FindAll()
        {
            return await _db.DanhMucPhongBans
                .ToListAsync();
        }

        public Task<DanhMucPhongBan> FindById(int id)
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

        public Task<bool> Update(DanhMucPhongBan entity)
        {
            throw new NotImplementedException();
        }
    }
}
