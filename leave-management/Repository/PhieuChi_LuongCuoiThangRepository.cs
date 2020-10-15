using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class PhieuChi_LuongCuoiThangRepository : IPhieuChi_LuongCuoiThangRepository
    {
        private readonly ApplicationDbContext db;

        public PhieuChi_LuongCuoiThangRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(PhieuChi_LuongCuoiThang entity)
        {
            await db.PhieuChi_LuongCuoiThangs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(PhieuChi_LuongCuoiThang entity)
        {
            db.PhieuChi_LuongCuoiThangs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<PhieuChi_LuongCuoiThang>> FindAll()
        {
            return await db.PhieuChi_LuongCuoiThangs
                .Include(q => q.NhanVienChiTien)
                .Include(q => q.NhanVienThuHoi)
                .Include(q => q.NhanVienXuatLuong)
                .ToListAsync();
        }

        public async Task<PhieuChi_LuongCuoiThang> FindById(string id)
        {
            return await db.PhieuChi_LuongCuoiThangs
                .Include(q => q.NhanVienChiTien)
                .Include(q => q.NhanVienThuHoi)
                .Include(q => q.NhanVienXuatLuong)
                .FirstOrDefaultAsync(q => q.MaPhieuChi == id);
        }

      

        public async Task<bool> isExist(string id)
        {
            return await db.PhieuChi_LuongCuoiThangs.AnyAsync(q => q.MaPhieuChi == id);
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(PhieuChi_LuongCuoiThang entity)
        {
            db.PhieuChi_LuongCuoiThangs.Update(entity);
            return await Save();
        }
    }
}
