using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LoaiGiayToTuyThan
    {
        [Key]
        public string MaLoaiGiayTo { get; set; }
        [Required]
        public string TenLoaiGiayTo { get; set; }
        public string GhiChu { get; set; }
    }
}
