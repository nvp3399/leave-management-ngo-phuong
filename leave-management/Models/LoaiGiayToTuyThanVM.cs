using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LoaiGiayToTuyThanVM
    {
        public string MaLoaiGiayTo { get; set; }
        public string TenLoaiGiayTo { get; set; }
        public string GhiChu { get; set; }
    }
}
