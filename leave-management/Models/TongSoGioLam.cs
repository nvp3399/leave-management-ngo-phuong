using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class TongSoGioLam
    {
        [DisplayName("Số giờ")]
        public int SoGio { get; set; }
        [DisplayName("Số phút")]
        public int SoPhut { get; set; }
    }
}
