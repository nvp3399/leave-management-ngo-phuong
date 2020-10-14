using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LoaiGiayToTuyThanRepository : ILoaiGiayToTuyThanRepository
    {
        private readonly ApplicationDbContext _db;

        public LoaiGiayToTuyThanRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LoaiGiayToTuyThan entity)
        {
            await _db.LoaiGiayToTuyThans.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LoaiGiayToTuyThan entity)
        {
            _db.LoaiGiayToTuyThans.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LoaiGiayToTuyThan>> FindAll()
        {
            return await _db.LoaiGiayToTuyThans
                .ToListAsync();
        }


        public async Task<LoaiGiayToTuyThan> FindById(string id_string)
        {
            return await _db.LoaiGiayToTuyThans
                    .FirstOrDefaultAsync(q => q.MaLoaiGiayTo == id_string);
        }


        public async Task<bool> isExist(string id)
        {
            var exists = await _db.LoaiGiayToTuyThans.AnyAsync(q => q.MaLoaiGiayTo == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(LoaiGiayToTuyThan entity)
        {
            _db.LoaiGiayToTuyThans.Update(entity);
            return await Save();
        }
    }
}
