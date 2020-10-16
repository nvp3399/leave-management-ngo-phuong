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
        public string ID { get; set; }
        public string MaPhieuChi { get; set; }




        public string MaNhanVien_NKLV { get; set; }

        public DateTime ThoiGianBatDau_NKLV { get; set; }

        //public virtual NhatKyLamViec NhatKyLamViec { get; set; }
        //public virtual PhieuChi_LuongCuoiThang PhieuChi_LuongCuoiThang { get; set; }
    }
}
