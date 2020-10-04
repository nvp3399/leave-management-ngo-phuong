using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class DanhMucChucVu
    {
        [Key]
        public string MaChucVu { get; set; }
        [Required]
        public string TenChucVu { get; set; }
        public string GhiChu { get; set; }

    }
}
