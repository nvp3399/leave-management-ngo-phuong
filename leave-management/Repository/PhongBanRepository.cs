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


        public async Task<DanhMucPhongBan> FindById(string id_string)
        {
            return await _db.DanhMucPhongBans.FirstOrDefaultAsync(q => q.MaPhongBan == id_string);
        }

        public async Task<DanhMucPhongBan> FindByName(string tenPhongBan)
        {
            return await _db.DanhMucPhongBans.FirstOrDefaultAsync(q => q.TenPhongBan.ToUpper() == tenPhongBan.ToUpper());
        }

        public Task<bool> isExist(string id_string)
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
