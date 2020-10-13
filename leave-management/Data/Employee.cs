using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class Employee : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string TaxtId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

        [Required]
        public bool GioiTinh { get; set; }
        public string NoiSinh { get; set; } 
        public string DiaChiTamTru { get; set; }
        public string DiaChiLienLac { get; set; }
        
        [ForeignKey("MaChucVu")]
        public DanhMucChucVu ChucVu { get; set; }
        public string MaChucVu { get; set; }
        [ForeignKey("MaChuyenMon")]
        public DanhMucChuyenMon ChuyenMon { get; set; }
        public string MaChuyenMon { get; set; }

        [ForeignKey("MaPhongBan")]
        public DanhMucPhongBan PhongBan { get; set; }
        public string MaPhongBan { get; set; }
        public string MaSoThue { get; set; }


        [Required]
        public int MucLuongCoBan { get; set; }
        [Required]
        public string LoaiNhanVien { get; set; }
        [ForeignKey("MaNhanVienThemVaoHeThong")]
        public Employee NhanVienThemVaoHeThong { get; set; }
        public string MaNhanVienThemVaoHeThong { get; set; }
        public string ViTriLuuAnhDaiDien { get; set; }

        
        public string SoCMND { get; set; }


        public string ProfilePicture { get; set; }
    }
}
