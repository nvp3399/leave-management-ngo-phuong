using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface INhatKylamViecRepository : IRepositoryStringKeyBase<NhatKyLamViec>
    {
        Task<ICollection<NhatKyLamViec>> FindByMaNhanVien(string employeeId);
        Task<ICollection<NhatKyLamViec>> FindByThoiGianBatDau(DateTime thoiGianBatDau);
        Task<ICollection<NhatKyLamViec>> FindByThoiGianKetThuc(DateTime thoiGianKetThuc);
        Task<ICollection<NhatKyLamViec>> FindByMaLoaiLichBieu(string maLoaiLichBieu);
        Task<NhatKyLamViec> FindByMaNhanVienAndThoiGianBatDau(string employeeId, DateTime thoiGianBatDau);

        Task<ICollection<NhatKyLamViec>> FindByMaNhanVienAndThangTinhLuong(string employeeId, int month, int year);


    }
}
