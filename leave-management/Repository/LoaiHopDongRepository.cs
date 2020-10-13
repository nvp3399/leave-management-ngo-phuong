using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LoaiHopDongRepository : ILoaiHopDongRepository
    {
        private readonly ApplicationDbContext db;

        public LoaiHopDongRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<bool> Create(LoaiHopDong entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(LoaiHopDong entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<LoaiHopDong>> FindAll()
        {
            return await db.LoaiHopDongs.ToListAsync();
        }



        public Task<LoaiHopDong> FindById(string id_string)
        {
            throw new NotImplementedException();
        }


        public Task<bool> isExist(string id_string)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LoaiHopDong entity)
        {
            throw new NotImplementedException();
        }
    }
}
