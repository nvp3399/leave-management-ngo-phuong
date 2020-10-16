using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChiListVM
    {
        public ICollection<PhieuChi_LuongCuoiThangVM> PhieuChi_LuongCuoiThangs { get; set; }
        public ICollection<PhieuChi_TamUngLuongVM> PhieuChi_TamUngLuongs { get; set; }
    }
}
