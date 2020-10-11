using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class ChuyenMonsVM
    {
        [DisplayName("Chuyên môn")]
        public string MaChuyenMon { get; set; }
        public string TenChuyenMon { get; set; }
        public string GhiChu { get; set; }

    }
}
