using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class PhieuChi_TamUngLuong : PhieuChi
    {

        [ForeignKey("MaYeuCauTamUngLuong")]
        public YeuCauTamUngLuong YeuCauTamUngLuong { get; set; }
        public string MaYeuCauTamUngLuong { get; set; }

    }
}
