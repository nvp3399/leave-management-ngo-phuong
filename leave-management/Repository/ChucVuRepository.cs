using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Data;
using leave_management.Contracts;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly ApplicationDbContext _db;

        public ChucVuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<bool> Create(DanhMucChucVu entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(DanhMucChucVu entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DanhMucChucVu>> FindAll()
        {
            return await _db.DanhMucChucVus
                .ToListAsync();

        }

        public Task<DanhMucChucVu> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(DanhMucChucVu entity)
        {
            throw new NotImplementedException();
        }
    }
}
