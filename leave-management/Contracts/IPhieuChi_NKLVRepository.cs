using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IPhieuChi_NKLVRepository : IRepositoryStringKeyBase<PhieuChi_NKLV>
    {
        Task<string> FindMaNhanVienByMaPhieuChi(string maPhieuChi);

        Task<ICollection< PhieuChi_NKLV>> FindByMaNhanVienAndNamTinhLuongAndThangTinhLuong(string employeeId, int month, int year);

        Task<bool> DaXuatPhieuChiHayChua(string employeeId, int month, int year);
    }
}
