using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class DanhMucChuyenMon
    {
        [Key]
        public string MaChuyenMon { get; set; }
        [Required]
        public string TenChuyenMon { get; set; }
        public string GhiChu { get; set; }

    }
}
