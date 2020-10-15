using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class PhieuChi_NKLV
    {
        [Key]
        public string MaPhieuChi { get; set; }



        public Employee NhanVien_NKLV { get; set; }

        [StringLength(450)]
        public string MaNhanVien_NKLV { get; set; }

        public DateTime ThoiGianBatDau_NKLV { get; set; }


    }
}
