using leave_management.Contracts;
using leave_management.Data;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class PhieuChi_NKLVRepository : IPhieuChi_NKLVRepository
    {
        private readonly ApplicationDbContext db;

        public PhieuChi_NKLVRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(PhieuChi_NKLV entity)
        {
            await db.PhieuChi_NKLVs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> DaXuatPhieuChiHayChua(string employeeId, int month, int year)
        {
            //Kiểm tra xem đã xuất phiếu chi hay chưa và có bất kỳ phiếu chi đã xuất nào có trạng thái là chưa thu hồi hay không.
            //Kiểm tra xem là đã chi tiền hay chưa.
            //Tên hàm nào cho hợp lý?
            var phieuchi_nklvs = await FindByMaNhanVienAndNamTinhLuongAndThangTinhLuong(employeeId, month, year);
            if (phieuchi_nklvs.Count ==0)
            {
                return false;
            }

            var maPhieuChi_LuongCuoiThangs = phieuchi_nklvs
                .Select(q => new { q.MaPhieuChi })
                .Distinct()
                ;



            var phieuchi_luongcuoithangs = (await db.PhieuChi_LuongCuoiThangs.ToListAsync())
                .Select(q => new { q.MaPhieuChi, q.MaNhanVienThuHoi, q.MaNhanVienChiTien })
                ;




            foreach (var maphieuchi_luongCuoiThang in maPhieuChi_LuongCuoiThangs)
            {
                foreach (var phieuchi_luongcuoiThang in phieuchi_luongcuoithangs)
                {
                    if (phieuchi_luongcuoiThang.MaPhieuChi == maphieuchi_luongCuoiThang.MaPhieuChi
                        && phieuchi_luongcuoiThang.MaNhanVienThuHoi == null
                        /*&& phieuchi_luongcuoiThang.MaNhanVienChiTien == null*/)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public async Task<bool> Delete(PhieuChi_NKLV entity)
        {
            db.PhieuChi_NKLVs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<PhieuChi_NKLV>> FindAll()
        {
            return await db.PhieuChi_NKLVs

                .ToListAsync();
        }

        public async Task<PhieuChi_NKLV> FindById(string id)
        {
            return await db.PhieuChi_NKLVs

                .FirstOrDefaultAsync(q => q.MaPhieuChi == id);
        }

        public async Task<ICollection<PhieuChi_NKLV>> FindByMaNhanVienAndNamTinhLuongAndThangTinhLuong(string employeeId, int month, int year)
        {
            var phieuChi = (await db.PhieuChi_NKLVs.ToListAsync())
                .Where(q => q.MaNhanVien_NKLV == employeeId && q.ThoiGianBatDau_NKLV.Month == month && q.ThoiGianBatDau_NKLV.Year == year)
                .ToList();

            return phieuChi;
                
        }

        public async Task<string> FindMaNhanVienByMaPhieuChi(string maPhieuChi)
        {
            var phieuChi = await db.PhieuChi_NKLVs.FirstOrDefaultAsync(q => q.MaPhieuChi == maPhieuChi);
            if (phieuChi == null)
            {
                return null;
            }

            return phieuChi.MaNhanVien_NKLV;

        }

        public async Task<bool> isExist(string id)
        {
            return await db.PhieuChi_NKLVs.AnyAsync(q => q.MaPhieuChi == id);
        }

        public async Task<bool> Save()
        {
            bool isSuccess = await db.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> Update(PhieuChi_NKLV entity)
        {
            db.PhieuChi_NKLVs.Update(entity);
            return await Save();
        }
    }
}
