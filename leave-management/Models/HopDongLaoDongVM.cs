using leave_management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class HopDongLaoDongVM
    {
        [DisplayName("Mã hợp đồng")]
        public string MaHopDong { get; set; }
        [DisplayName("Ngày ký kết")]
        [DataType(DataType.Date)]
        public DateTime NgayKyKet { get; set; }
        [DisplayName("Ngày có hiệu lực")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [DisplayName("Ngày hết hiệu lực")]
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }
        public string ViTriLuuBanScan { get; set; }
        [DisplayName("Ngày hợp đồng tải lên")]
        public DateTime NgayGuiBanScan { get; set; }

        public string MaNhanVienGuiBanScan { get; set; }
        [DisplayName("Được tải lên bởi")]
        public EmployeeVM NhanVienGuiBanScan { get; set; }

        public string MaNhanVienChuTheHopDong { get; set; }
        [DisplayName("Nhân viên chủ thể hợp đồng")]
        public EmployeeVM NhanVienChuTheHopDong { get; set; }

        public MauHopDongVM MauHopDong { get; set; }
        [DisplayName("Mẫu hợp đồng")]
        [Required]
        public string MaMauHopDong { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }
        [DisplayName("Ngày hợp đồng bị hủy")]
        public DateTime NgayHopDongBiHuy { get; set; }
        [DisplayName("Nhân viên hủy hợp đồng")]
        public EmployeeVM NhanVienHuyHopDong { get; set; }
        public string MaNhanVienHuyHopDong { get; set; }
        [DisplayName("Tải lên file Scan của hợp đồng")]
        public IFormFile FileHopDongScan { get; set; }

        [DisplayName("Được chỉnh sửa lần cuối bởi")]
        public EmployeeVM NhanVienChinhSuaLanCuoi { get; set; }
        public string MaNhanVienChinhSuaLanCuoi { get; set; }
        [DisplayName("Thời gian chỉnh sửa lần cuối")]
        public DateTime ThoiGianChinhSuaLanCuoi { get; set; }


    }

    public class CreateEditHopDongLaoDongVM : HopDongLaoDongVM
    {
        public IEnumerable<SelectListItem> MauHopDongs { get; set; }
    }

    public class ListHopDongLaoDongVM
    {
        public EmployeeVM EmployeeChuTheHopDong { get; set; }
        public IEnumerable<HopDongLaoDongVM> HopDongLaoDongVMs { get; set; }

    }
}
