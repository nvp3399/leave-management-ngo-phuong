using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChi_LuongCuoiThangVM : PhieuChiVM
    {


        public EmployeeVM NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }


    }
}
