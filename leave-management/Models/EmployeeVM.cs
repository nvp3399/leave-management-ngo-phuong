using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using leave_management.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
   

    public class EmployeeVM
    {
        public string Id { get; set; }
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Tên")]
        public string Firstname { get; set; }

        [DisplayName("Tên đệm")]
        public string MiddleName { get; set; }

        [DisplayName("Họ")]
        public string LastName { get; set; }
        [DisplayName("Mã số thuế")]
        public string TaxtId { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Ngày gia nhập")]
        public DateTime DateJoined { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }
        [DisplayName("Nơi sinh")]
        public string NoiSinh { get; set; }
        [DisplayName("Địa chỉ tạm trú")]
        public string DiaChiTamTru { get; set; }
        [DisplayName("Địa chỉ liên lạc")]
        public string DiaChiLienLac { get; set; }

        public ChucVusVM ChucVu { get; set; }
        public ChuyenMonsVM ChuyenMon { get; set; }

        public PhongBansVM PhongBan { get; set; }

        public HopDongLaoDongVM HopDong { get; set; }

        [DisplayName("Mức lương cơ bản")]
        public int MucLuongCoBan { get; set; }
        [DisplayName("Loại nhân viên")]
        public string LoaiNhanVien { get; set; }
        public EmployeeVM NhanVienThemVaoHeThong { get; set; }

        public string ViTriLuuAnhDaiDien { get; set; }


    }

    public class CreateEmployeeVM
    {
        public string Id { get; set; }
        [DisplayName("Địa chỉ Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Mật khẩu")]
        [Required]
        public string Password { get; set; }


        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Tên")]
        [Required]
        public string Firstname { get; set; }
        [DisplayName("Tên đệm")]
        public string MiddleName { get; set; }
        [DisplayName("Họ")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Mã số thuế")]
        public string TaxtId { get; set; }
        [DisplayName("Ngày sinh")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Ngày gia nhập")]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        [DisplayName("Giới tính")]
        [Required]
        public bool GioiTinh { get; set; }
        [DisplayName("Nơi sinh")]
        public string NoiSinh { get; set; }
        [DisplayName("Địa chỉ tạm trú")]
        public string DiaChiTamTru { get; set; }
        [DisplayName("Địa chỉ liên lạc")]
        public string DiaChiLienLac { get; set; }

        [DisplayName("Chức vụ")]
        [Required]
        public string MaChucVu { get; set; }
        public ChucVusVM ChucVu { get; set; }

        [DisplayName("Chuyên môn")]
        [Required]
        public string MaChuyenMon { get; set; }
        public ChuyenMonsVM ChuyenMon { get; set; }

        [DisplayName("Phòng ban")]
        [Required]
        public string MaPhongBan { get; set; }
        public PhongBansVM PhongBan { get; set; }

        public HopDongLaoDongVM HopDong { get; set; }

        public IEnumerable<SelectListItem> CacChucVu { get; set; }
        public IEnumerable<SelectListItem> CacChuyenMon { get; set; }
        public IEnumerable<SelectListItem> CacPhongBan { get; set; }

        public List<string> CacLoaiNhanVien { get; set; }



        [DisplayName("Mức lương cơ bản")]
        public int MucLuongCoBan { get; set; }
        [DisplayName("Loại nhân viên")]
        public string LoaiNhanVien { get; set; }
        public EmployeeVM NhanVienThemVaoHeThong { get; set; }




    }
}
