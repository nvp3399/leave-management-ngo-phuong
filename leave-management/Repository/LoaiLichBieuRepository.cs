using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LoaiLichBieuRepository : ILoaiLichBieuRepository
    {
        private readonly ApplicationDbContext _db;

        public LoaiLichBieuRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LoaiLichBieu entity)
        {
            await _db.LoaiLichBieus.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LoaiLichBieu entity)
        {
            _db.LoaiLichBieus.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LoaiLichBieu>> FindAll()
        {
            return await _db.LoaiLichBieus
                .ToListAsync();
        }


        public async Task<LoaiLichBieu> FindById(string id_string)
        {
            return await _db.LoaiLichBieus
                    .FirstOrDefaultAsync(q => q.MaLoai == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.LoaiLichBieus.AnyAsync(q => q.MaLoai == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(LoaiLichBieu entity)
        {
            _db.LoaiLichBieus.Update(entity);
            return await Save();
        }
    }
}
