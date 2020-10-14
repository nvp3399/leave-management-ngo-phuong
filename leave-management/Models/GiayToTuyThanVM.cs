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
    public class GiayToTuyThanVM
    {
        [Required]
        public string MaNhanVien { get; set; }
        public EmployeeVM NhanVien { get; set; }


        public LoaiGiayToTuyThanVM LoaiGiayTo { get; set; }

        [Required]

        public string MaLoaiGiayTo { get; set; }
        public DateTime NgayLuuVaoHeThong { get; set; }

        public EmployeeVM NhanVienGui { get; set; }
        public string MaNhanVienGui { get; set; }
        public string ViTriLuuBanScan { get; set; }
        public string GhiChu { get; set; }

        [DisplayName("Tải lên file Scan của hợp đồng")]
        public IFormFile FileGiayToTuyThanScan { get; set; }

        [DisplayName("Được chỉnh sửa lần cuối bởi")]
        public EmployeeVM NhanVienChinhSuaLanCuoi { get; set; }
        public string MaNhanVienChinhSuaLanCuoi { get; set; }
        [DisplayName("Thời gian chỉnh sửa lần cuối")]
        public DateTime ThoiGianChinhSuaLanCuoi { get; set; }
    }

    public class CreateEditGiayToTuyThanVM : GiayToTuyThanVM
    {
        public IEnumerable<SelectListItem> MauGiayToTuyThans { get; set; }
    }

    public class ListGiayToTuyThanVM
    {
        public EmployeeVM NhanVien { get; set; }
        public IEnumerable<GiayToTuyThanVM> GiayToTuyThanVMs { get; set; }

    }
}
