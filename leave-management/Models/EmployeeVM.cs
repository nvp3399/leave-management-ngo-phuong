using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using leave_management.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace leave_management.Models
{
   

    public class EmployeeVM
    {
        public string Id { get; set; }
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập địa chỉ email")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Tên")]
        public string FirstName { get; set; }

        [DisplayName("Tên đệm")]
        public string MiddleName { get; set; }

        [DisplayName("Họ")]
        public string LastName { get; set; }
        [DisplayName("Mã số thuế")]
        public string TaxtId { get; set; }
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
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

        [DisplayName("Chức vụ")]
        [Required(ErrorMessage ="Vui lòng chọn chức vụ")]
        public string MaChucVu { get; set; }
        [DisplayName("Chuyên môn")]

        [Required(ErrorMessage = "Vui lòng chọn chuyên môn")]
        public string MaChuyenMon { get; set; }
        [DisplayName("Phòng ban")]
        [Required(ErrorMessage = "Vui lòng chọn phòng ban")]
        public string MaPhongBan { get; set; }

        [DisplayName("Mức lương cơ bản")]
        public int MucLuongCoBan { get; set; }
        [DisplayName("Loại nhân viên")]
        [Required(ErrorMessage = "Vui lòng chọn loại nhân viên")]
        public string LoaiNhanVien { get; set; }

        [DisplayName("Được thêm vào hệ thống bởi")]
        public EmployeeVM NhanVienThemVaoHeThong { get; set; }

        public string ViTriLuuAnhDaiDien { get; set; }

        [DisplayName("Số CMND")]
        public string SoCMND { get; set; }

        [DisplayName("Vai Trò trên hệ thống")]
        public IdentityRole VaiTroTrenHeThong { get; set; }
        [DisplayName("Vai Trò trên hệ thống")]
        [Required(ErrorMessage = "Vui lòng chọn vai trò")]

        public string MaVaiTroTrenHeThong { get; set; }


        [Display(Name = "Ảnh đại diện")]
        public IFormFile ProfileImage { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string ProfilePicture { get; set; }
    }

    public class CreateEmployeeVM : EmployeeVM
    {
        
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        public IEnumerable<SelectListItem> CacChucVu { get; set; }
        public IEnumerable<SelectListItem> CacChuyenMon { get; set; }
        public IEnumerable<SelectListItem> CacPhongBan { get; set; }
        public IEnumerable<SelectListItem> CacVaiTro { get; set; }
        public List<string> CacLoaiNhanVien { get; set; }

    }

    public class EditEmployeeVM : CreateEmployeeVM
    {
       

    }

   
}
