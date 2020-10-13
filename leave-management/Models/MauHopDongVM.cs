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
    public class MauHopDongVM
    {
        [DisplayName("Mã mẫu")]
        public string MaMauHopDong { get; set; }
        [DisplayName("Tên mẫu")]
        [Required(ErrorMessage ="Tên mẫu bị bỏ trống")]
        public string TenMauHopDong { get; set; }
        [DisplayName("Nhân viên tạo")]
        public EmployeeVM NhanVienLuuMauHopDong { get; set; }
        [DisplayName("Được tạo bởi")]
        public string MaNhanVienLuuMauHopDong { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayGuiMauHopDong { get; set; }
        [DisplayName("Mẫu")]
        public string ViTriLuuMauHopDong { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }
        [DisplayName("Loại hợp đồng")]
        public LoaiHopDongVM LoaiHopDong { get; set; }
        [Required(ErrorMessage ="Loại hợp đồng bị bỏ trống")]
        [DisplayName("Loại hợp đồng")]
        public string MaLoaiHopDong { get; set; }
        [DisplayName("File mẫu hợp đồng")]
        public IFormFile FileMauHopDong { get; set; }

        
        public EmployeeVM NhanVienChinhSuaLanCuoi { get; set; }
        [DisplayName("Được chỉnh sửa lần cuối bởi")]
        public string MaNhanVienChinhSuaLanCuoi { get; set; }
        [DisplayName("Được chỉnh sửa lần cuối vào lúc")]
        public DateTime ThoiGianChinhSuaLanCuoi { get; set; }
    }

    public class CreateEditMauHopDongVM : MauHopDongVM
    {
        public IEnumerable<SelectListItem> LoaiHopDongs { get; set; }


    }

    public class HomeIndexMauHopDongVM
    {
        public IEnumerable<MauHopDongVM> mauHopDongVMs { get; set; }
        public IEnumerable<EmployeeVM> EmployeeVMs { get; set; }
    }

}
