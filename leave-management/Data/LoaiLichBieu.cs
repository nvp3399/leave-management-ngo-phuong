using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LoaiLichBieu
    {
        [Key]
        public string MaLoai { get; set; }
        [Required]
        public string TenLoaiLichBieu { get; set; }
        [Required]
        public float HeSoLuongCoBan { get; set; }

    }
}
