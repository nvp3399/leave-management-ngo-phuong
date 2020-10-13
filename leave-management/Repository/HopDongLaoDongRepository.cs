using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class HopDongLaoDongRepository : IHopDongLaoDongRepository
    {
        private readonly ApplicationDbContext _db;

        public HopDongLaoDongRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(HopDongLaoDong entity)
        {
            await _db.HopDongLaoDongs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(HopDongLaoDong entity)
        {
            _db.HopDongLaoDongs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<HopDongLaoDong>> FindAll()
        {
            return await _db.HopDongLaoDongs
                .Include(q => q.NhanVienGuiBanScan)
                .Include(q => q.NhanVienChuTheHopDong)
                .Include(q => q.MauHopDong)
                .ToListAsync();
        }

        public async Task< IEnumerable<HopDongLaoDong>> FindByEmployeeChuTheId(string employeeId)
        {
            return await _db.HopDongLaoDongs
                .Include(q => q.NhanVienGuiBanScan)
                .Include(q => q.NhanVienChuTheHopDong)
                .Include(q => q.MauHopDong)
                .Include(q => q.NhanVienChinhSuaLanCuoi)
                .Where(q => q.MaNhanVienChuTheHopDong == employeeId)
                .ToListAsync();
        }

        public async Task<HopDongLaoDong> FindById(string id_string)
        {
            return await _db.HopDongLaoDongs
                    .Include(q => q.NhanVienGuiBanScan)
                    .Include(q => q.NhanVienChuTheHopDong)
                    .Include(q => q.MauHopDong)
                    .Include(q => q.NhanVienChinhSuaLanCuoi)
                    .FirstOrDefaultAsync(q => q.MaHopDong == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.HopDongLaoDongs.AnyAsync(q => q.MaHopDong == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(HopDongLaoDong entity)
        {
            _db.HopDongLaoDongs.Update(entity);
            return await Save();
        }
    }
}
