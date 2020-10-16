using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChi_NKLVVM
    {
        
        public string MaPhieuChi { get; set; }


        public string MaNhanVien_NKLV { get; set; }

        public DateTime ThoiGianBatDau_NKLV { get; set; }

        [DisplayName("Lịch sử chấm công")]
        public LichSuChamCongVM NhatKyLamViec { get; set; }
        [DisplayName("Phiếu chi - lương cuối tháng")]
        public PhieuChi_LuongCuoiThangVM PhieuChi_LuongCuoiThang { get; set; }
    }
}
