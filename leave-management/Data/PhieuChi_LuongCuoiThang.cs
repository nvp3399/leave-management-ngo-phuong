using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class PhieuChi_LuongCuoiThang : PhieuChi
    {
       

        [ForeignKey("MaNhanVienXuatLuong")]
        public Employee NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }


    }
}
