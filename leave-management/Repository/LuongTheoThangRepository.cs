using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LuongTheoThangRepository : ILuongTheoThangRepository
    {
        private readonly ApplicationDbContext _db;

        public LuongTheoThangRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LuongTheoThang entity)
        {
            await _db.LuongTheoThangs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LuongTheoThang entity)
        {
            _db.LuongTheoThangs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LuongTheoThang>> FindAll()
        {
            return await _db.LuongTheoThangs
                .Include(q => q.NhanVien)
                .ToListAsync();
        }



        public async Task<LuongTheoThang> FindById(string id_string)
        {
            //return await _db.LuongTheoThangs
            //        .Include(q => q.NhanVien)
            //        .FirstOrDefaultAsync(q => q.MaHopDong == id_string);
            throw new NotImplementedException();
        }


        public async Task<bool> isExist(string id)
        {
            //var exists = await _db.LuongTheoThangs.AnyAsync(q => q.MaHopDong == id);
            //return exists;
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(LuongTheoThang entity)
        {
            _db.LuongTheoThangs.Update(entity);
            return await Save();
        }
    }
}
