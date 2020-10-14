using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class GiayToTuyThanRepository : IGiayToTuyThanRepository
    {
        private readonly ApplicationDbContext _db;

        public GiayToTuyThanRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(GiayToTuyThan entity)
        {
            await _db.GiayToTuyThans.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(GiayToTuyThan entity)
        {
            _db.GiayToTuyThans.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<GiayToTuyThan>> FindAll()
        {
            return await _db.GiayToTuyThans
                           .Include(q => q.NhanVien)
                           .Include(q => q.NhanVienGui)
                           .Include(q => q.NhanVienChinhSuaLanCuoi)
                           .Include(q => q.LoaiGiayTo)
                           .ToListAsync();
        }

        public async Task<GiayToTuyThan> FindById(string id)
        {
            //return await _db.GiayToTuyThans
            //        .Include(q => q.NhanVien)
            //        .Include(q => q.NhanVienGui)
            //        .FirstOrDefaultAsync(q => q.MaHopDong == id_string);
            throw new NotImplementedException();
        }

        public async Task<bool> isExist(string id)
        {
            //var exists = await _db.GiayToTuyThans.AnyAsync(q => q.MaHopDong == id);
            //return exists;
            throw new NotImplementedException();
        }

        public Task<bool> isExist(string employeeId, string maLoaiGiayTo)
        {
            var exists =  _db.GiayToTuyThans.AnyAsync(q => q.MaNhanVien == employeeId && q.MaLoaiGiayTo == maLoaiGiayTo);
            return exists;
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(GiayToTuyThan entity)
        {
            _db.GiayToTuyThans.Update(entity);
            return await Save();
        }
    }
}
