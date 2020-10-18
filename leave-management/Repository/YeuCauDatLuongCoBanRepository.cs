using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static leave_management.GeneralData.Data;

namespace leave_management.Repository
{
    public class YeuCauDatLuongCoBanRepository : IYeuCauDatLuongCoBanRepository
    {
        private readonly ApplicationDbContext _db;

        public YeuCauDatLuongCoBanRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(YeuCauDatLuongCoBan entity)
        {
            await _db.YeuCauDatLuongCoBans.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(YeuCauDatLuongCoBan entity)
        {
            _db.YeuCauDatLuongCoBans.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<YeuCauDatLuongCoBan>> FindAll()
        {
            return await _db.YeuCauDatLuongCoBans
                .Include(q => q.NhanVienGuiYeuCau)
                .Include(q => q.NhanVienDuocDatLuong)
                .Include(q => q.NhanVienPheDuyet)
                .ToListAsync();
        }

        //public async Task<IEnumerable<YeuCauDatLuongCoBan>> FindByEmployeeChuTheId(string employeeId)
        //{
        //    return await _db.YeuCauDatLuongCoBans
        //        .Include(q => q.NhanVienGuiYeuCau)
        //        .Include(q => q.NhanVienDuocDatLuong)
        //        .Include(q => q.NhanVienPheDuyet)
        //        .ToListAsync();
        //}

        public async Task<YeuCauDatLuongCoBan> FindById(string id_string)
        {
            return await _db.YeuCauDatLuongCoBans
                    .Include(q => q.NhanVienGuiYeuCau)
                .Include(q => q.NhanVienDuocDatLuong)
                .Include(q => q.NhanVienPheDuyet)
                    .FirstOrDefaultAsync(q => q.MaYeuCau == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.YeuCauDatLuongCoBans.AnyAsync(q => q.MaYeuCau == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        

        public async Task<bool> Update(YeuCauDatLuongCoBan entity)
        {
            _db.YeuCauDatLuongCoBans.Update(entity);
            return await Save();
        }
    }
}
