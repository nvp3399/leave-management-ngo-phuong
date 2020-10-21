using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhongBansVM
    {
        [DisplayName("Phòng ban")]
        public string MaPhongBan { get; set; }
        [DisplayName("Tên phòng ban")]
        public string TenPhongBan { get; set; }

        
        public EmployeeVM NhanVienTruongPhong { get; set; }
        
        public string MaNhanVienTruongPhong { get; set; }
    }
}
