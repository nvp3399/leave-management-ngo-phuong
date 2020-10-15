using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class PhieuChi_TamUngLuongRepository : IPhieuChi_TamUngLuongRepository
    {
        private readonly ApplicationDbContext db;

        public PhieuChi_TamUngLuongRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(PhieuChi_TamUngLuong entity)
        {
            await db.PhieuChi_TamUngLuongs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(PhieuChi_TamUngLuong entity)
        {
            db.PhieuChi_TamUngLuongs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<PhieuChi_TamUngLuong>> FindAll()
        {
            return await db.PhieuChi_TamUngLuongs
                .Include(q => q.NhanVienChiTien)
                .Include(q => q.NhanVienThuHoi)
                .Include(q => q.YeuCauTamUngLuong)
                .ToListAsync();
        }

        public async Task<PhieuChi_TamUngLuong> FindById(string id)
        {
            return await db.PhieuChi_TamUngLuongs
                .Include(q => q.NhanVienChiTien)
                .Include(q => q.NhanVienThuHoi)
                .Include(q => q.YeuCauTamUngLuong)
                .FirstOrDefaultAsync(q => q.MaPhieuChi == id);
        }



        public async Task<bool> isExist(string id)
        {
            return await db.PhieuChi_TamUngLuongs.AnyAsync(q => q.MaPhieuChi == id);
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(PhieuChi_TamUngLuong entity)
        {
            db.PhieuChi_TamUngLuongs.Update(entity);
            return await Save();
        }
    }
}
