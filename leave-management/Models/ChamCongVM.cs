using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class ChamCongVM : EmployeeVM
    {
        public ChamCongVM()
        {
            TongSoGio = new TongSoGioLam();
        }
        [DisplayName("Tổng số giờ làm trong tháng")]
        public TongSoGioLam TongSoGio { get; set; }
        [DisplayName("Tổng tiền lương cơ bản(basic) đã tích lũy trong tháng")]
        public int TongTienLuongCoBanDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền thưởng (bonus) đã tích lũy trong tháng")]
        public int TongTienThuongDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền lương đã tích lũy trong tháng")]
        public int TongTienLuong { get; set; }

        public bool TrangThaiXuatLuong { get; set; }


    }

    public class ChamCongVMList
    {
        public IEnumerable<ChamCongVM> ChamCongList { get; set; }

        

        public IEnumerable<SelectListItem> MonthsInYear { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }

        public ChamCongVMListViewForm ViewForm { get; set; }
    }

    public class ChamCongVMListViewForm
    {
        [DisplayName("Chọn tháng")]
        [Required]
        public string CurrentMonth { get; set; }
        [DisplayName("Chọn năm")]
        [Required]
        public string CurrentYear { get; set; }
    }
}
