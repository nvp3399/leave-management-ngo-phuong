using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class GiayToTuyThanVM
    {
        public EmployeeVM NhanVien { get; set; }

        public LoaiGiayToTuyThanVM LoaiGiayTo { get; set; }
        public DateTime NgayLuuVaoHeThong { get; set; }

        public EmployeeVM NhanVienGui { get; set; }
        public string ViTriLuuBanScan { get; set; }
        public string GhiChu { get; set; }

    }
}
