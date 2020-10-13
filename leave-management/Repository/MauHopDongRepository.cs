using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace leave_management.Repository
{
    public class MauHopDongRepository : IMauHopDongRepository
    {
        private readonly ApplicationDbContext _db;

        public MauHopDongRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(MauHopDong entity)
        {
            await _db.MauHopDongs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(MauHopDong entity)
        {
            _db.MauHopDongs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<MauHopDong>> FindAll()
        {
            return await _db.MauHopDongs
                .Include(q => q.LoaiHopDong)
                .Include(q => q.NhanVienLuuMauHopDong)
                .Include(q => q.NhanVienChinhSuaLanCuoi)
                .ToListAsync();
        }



        public async Task<MauHopDong> FindById(string id_string)
        {
            return await _db.MauHopDongs
                    .Include(q => q.LoaiHopDong)
                    .Include(q => q.NhanVienLuuMauHopDong)
                    .Include(q => q.NhanVienChinhSuaLanCuoi)
                    .FirstOrDefaultAsync(q => q.MaMauHopDong == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.MauHopDongs.AnyAsync(q => q.MaMauHopDong == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(MauHopDong entity)
        {
            _db.MauHopDongs.Update(entity);
            return await Save();
        }
    }
}
