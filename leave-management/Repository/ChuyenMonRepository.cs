using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    public class ChuyenMonRepository : IChuyenMonRepository
    {
        private readonly ApplicationDbContext _db;

        public ChuyenMonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> Create(DanhMucChuyenMon entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(DanhMucChuyenMon entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DanhMucChuyenMon>> FindAll()
        {
            return await _db.DanhMucChuyenMons.ToListAsync();
            
        }

        public Task<DanhMucChuyenMon> FindById(int id)
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

        public Task<bool> Update(DanhMucChuyenMon entity)
        {
            throw new NotImplementedException();
        }
    }
}
