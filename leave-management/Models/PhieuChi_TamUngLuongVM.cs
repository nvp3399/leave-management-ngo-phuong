using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChi_TamUngLuongVM : PhieuChiVM
    {

        public YeuCauTamUngLuongVM YeuCauTamUngLuong { get; set; }
        public string MaYeuCauTamUngLuong { get; set; }

    }
}
