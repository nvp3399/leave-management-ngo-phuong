using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class PhieuChiRepository : IPhieuChiRepository
    {
        private readonly ApplicationDbContext _db;

        public PhieuChiRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(PhieuChi entity)
        {
            await _db.PhieuChis.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(PhieuChi entity)
        {
            _db.PhieuChis.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<PhieuChi>> FindAll()
        {
            return await _db.PhieuChis
                .Include(q => q.NhanVien)
                .Include(q => q.NhanVienXuatPhieu)
                .Include(q => q.NhanVienChiTien)
                .ToListAsync();
        }



        public async Task<PhieuChi> FindById(string id_string)
        {
            //return await _db.PhieuChis
            //        .Include(q => q.NhanVien)
            //        .Include(q => q.NhanVienXuatPhieu)
            //        .Include(q => q.NhanVienChiTien)
            //        .FirstOrDefaultAsync(q => q.MaHopDong == id_string);
            throw new NotImplementedException();
        }


        public async Task<bool> isExist(string id)
        {
            //var exists = await _db.PhieuChis.AnyAsync(q => q.MaHopDong == id);
            //return exists;

            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await _db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(PhieuChi entity)
        {
            _db.PhieuChis.Update(entity);
            return await Save();
        }
    }
}
