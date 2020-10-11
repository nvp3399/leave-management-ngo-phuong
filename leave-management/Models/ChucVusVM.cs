using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace leave_management.Models
{
    public class ChucVusVM
    {
        [DisplayName("Chức vụ")]
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public string GhiChu { get; set; }

    }
}
