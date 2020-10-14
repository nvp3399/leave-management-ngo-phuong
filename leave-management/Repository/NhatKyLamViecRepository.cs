using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class NhatKyLamViecRepository : INhatKylamViecRepository
    {
        private readonly ApplicationDbContext db;

        public NhatKyLamViecRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(NhatKyLamViec entity)
        {
            await db.NhatKyLamViecs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(NhatKyLamViec entity)
        {
            db.NhatKyLamViecs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<NhatKyLamViec>> FindAll()
        {
            return await db.NhatKyLamViecs
                .Include(q => q.NhanVien)
                .Include(q => q.LoaiLichBieu)
                .Include(q => q.NhanVienThemVaoHeThong)
                .ToListAsync();
        }

        public async Task<NhatKyLamViec> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NhatKyLamViec>> FindByMaLoaiLichBieu(string maLoaiLichBieu)
        {
            return (await db.NhatKyLamViecs
                .Include(q => q.NhanVien)
                .Include(q => q.LoaiLichBieu)
                .Include(q => q.NhanVienThemVaoHeThong)
                .ToListAsync())
                .Where(q => q.MaLoaiLichBieu == maLoaiLichBieu)
                .ToList();
        }

        public async Task<ICollection<NhatKyLamViec>> FindByMaNhanVien(string employeeId)
        {
            return (await db.NhatKyLamViecs
                .Include(q => q.NhanVien)
                .Include(q =>q.LoaiLichBieu)
                .Include(q => q.NhanVienThemVaoHeThong)
                .ToListAsync())
                .Where(q => q.MaNhanVien == employeeId)
                .ToList();
                
        }

        public async Task<NhatKyLamViec> FindByMaNhanVienAndThoiGianBatDau(string employeeId, DateTime thoiGianBatDau)
        {

            return (await db.NhatKyLamViecs
                .Include(q => q.NhanVien)
                .Include(q => q.LoaiLichBieu)
                .Include(q => q.NhanVienThemVaoHeThong)
                .FirstOrDefaultAsync(q => q.MaNhanVien == employeeId && q.ThoiGianBatDau == thoiGianBatDau));

        }

        public async Task<ICollection<NhatKyLamViec>> FindByThoiGianBatDau(DateTime thoiGianBatDau)
        {
            return (await db.NhatKyLamViecs
                .Include(q => q.NhanVien)
                .Include(q => q.LoaiLichBieu)
                .Include(q => q.NhanVienThemVaoHeThong)
                .ToListAsync())
                .Where(q => q.ThoiGianBatDau == thoiGianBatDau)
                .ToList();
        }

        public async Task<ICollection<NhatKyLamViec>> FindByThoiGianKetThuc(DateTime thoiGianKetThuc)
        {
            return (await db.NhatKyLamViecs
                 .Include(q => q.NhanVien)
                 .Include(q => q.LoaiLichBieu)
                 .Include(q => q.NhanVienThemVaoHeThong)
                 .ToListAsync())
                 .Where(q => q.ThoiGianKetThuc == thoiGianKetThuc)
                 .ToList();
        }

        public async Task<bool> isExist(string id)
        {
            //var exists = await db.NhatKyLamViecs.AnyAsync(q => q.MaHopDong == id);
            //return exists;
            throw new NotImplementedException();

        }

        public async Task<bool> Save()
        {
            bool isSuccess = await db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(NhatKyLamViec entity)
        {
            db.NhatKyLamViecs.Update(entity);
            return await Save();
        }
    }
}
