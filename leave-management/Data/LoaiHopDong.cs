﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LoaiHopDong
    {
        [Key]
        public string MaLoaiHopDong { get; set; }
        [Required]
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }
    }
}
