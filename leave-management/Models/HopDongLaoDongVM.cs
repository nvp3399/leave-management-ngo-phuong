using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class HopDongLaoDongVM
    {
        public string MaHopDong { get; set; }
        public DateTime NgayKyKet { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string ViTriLuuBanScan { get; set; }
        public DateTime NgayGuiBanScan { get; set; }

        /*
        public EmployeeVM NhanVienGuiBanScan { get; set; }


        public EmployeeVM MaNhanVienChuTheHopDong { get; set; }
        */

        public MauHopDongVM MauHopDong { get; set; }
        public string MaMauHopDong { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayHopDongBiHuy { get; set; }
        public string MaNhanVienHuyHopDong { get; set; }

    }
}
