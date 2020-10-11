using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LoaiHopDongVM
    {
        public string MaLoaiHopDong { get; set; }
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }
    }
}
