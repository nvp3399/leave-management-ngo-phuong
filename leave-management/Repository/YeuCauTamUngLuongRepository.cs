using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class YeuCauTamUngLuongRepository : IYeuCauTamUngLuongRepository
    {
        private readonly ApplicationDbContext _db;

        public YeuCauTamUngLuongRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(YeuCauTamUngLuong entity)
        {
            await _db.YeuCauTamUngLuongs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(YeuCauTamUngLuong entity)
        {
            _db.YeuCauTamUngLuongs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<YeuCauTamUngLuong>> FindAll()
        {
            return await _db.YeuCauTamUngLuongs
                .Include(q => q.NhanVienGuiYeuCau)
                .Include(q => q.NhanVienPheDuyet)
                .ToListAsync();
        }

        //public async Task<IEnumerable<YeuCauTamUngLuong>> FindByEmployeeChuTheId(string employeeId)
        //{
        //    return await _db.YeuCauTamUngLuongs
        //        .Include(q => q.NhanVienGuiBanScan)
        //        .Include(q => q.NhanVienChuTheHopDong)
        //        .Include(q => q.MauHopDong)
        //        .Include(q => q.NhanVienChinhSuaLanCuoi)
        //        .Where(q => q.MaNhanVienChuTheHopDong == employeeId)
        //        .ToListAsync();
        //}

        public async Task<YeuCauTamUngLuong> FindById(string id_string)
        {
            return await _db.YeuCauTamUngLuongs
                   .Include(q => q.NhanVienGuiYeuCau)
                .Include(q => q.NhanVienPheDuyet)
                    .FirstOrDefaultAsync(q => q.MaYeuCau == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.YeuCauTamUngLuongs.AnyAsync(q => q.MaYeuCau == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(YeuCauTamUngLuong entity)
        {
            _db.YeuCauTamUngLuongs.Update(entity);
            return await Save();
        }
    }
}
