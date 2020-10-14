using leave_management.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class NhatKyLamViecVM
    {
        
        public string MaNhanVien { get; set; }
        [DisplayName("Tên nhân viên")]
        public EmployeeVM NhanVien { get; set; }

        [DisplayName("Thời gian bắt đầu")]
        public DateTime ThoiGianBatDau { get; set; }
        [DisplayName("Thời gian kết thúc")]
        public DateTime ThoiGianKetThuc { get; set; }

        [Required]
        [DisplayName("Loại lịch biểu")]
        public string MaLoaiLichBieu { get; set; }
        public LoaiLichBieuVM LoaiLichBieu { get; set; }
        [DisplayName("Số tiền thưởng thêm")]
        public int SoTienThuongThem { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Nhân viên thêm vào hệ thống")]
        public EmployeeVM NhanVienThemVaoHeThong { get; set; }
        public string MaNhanVienThemVaoHeThong { get; set; }

        [DisplayName("Ngày thêm vào hệ thống")]
        public DateTime NgayThemVaoHeThong { get; set; }

    }

    public class CreateEditNhatKyLamViecVM : NhatKyLamViecVM
    {
        public IEnumerable<SelectListItem> LoaiLichBieus { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày")]
        [Required]
        public DateTime Date { get; set; }


        [DisplayName("Giờ")]
        [Required]
        public string StartHour { get; set; }
        [DisplayName("Phút")]
        [Required]
        public string StartMinute { get; set; }
        [DisplayName("Giờ")]
        [Required]
        public string EndHour { get; set; }
        [DisplayName("Phút")]
        [Required]
        public string EndMinute { get; set; }


        public IEnumerable<SelectListItem> HoursOfDay { get; set; }
        public IEnumerable<SelectListItem> MinutesOfHour { get; set; }
    }


}
