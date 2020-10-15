using leave_management.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class YeuCauDatLuongCoBanVM
    {
        public string MaYeuCau { get; set; }

        public string MaNhanVienGuiYeuCau { get; set; }

        [DisplayName("Nhân viên gửi yêu cầu")]
        public EmployeeVM NhanVienGuiYeuCau { get; set; }
        [Required]
        public string MaNhanVienDuocDatLuong { get; set; }

        [DisplayName("Nhân viên được đặt lương")]
        public EmployeeVM NhanVienDuocDatLuong { get; set; }
        [DisplayName("Mức lương được đặt")]
        [Required]
        public int MucLuongCoBan { get; set; }
        [DisplayName("Thời gian gửi yêu cầu")]

        public DateTime ThoiGianGuiYeuCau { get; set; }
        [DisplayName("Thời gian phê duyệt")]
        public DateTime ThoiGianPheDuyet { get; set; }
        public string MaNhanVienPheDuyet { get; set; }
        [DisplayName("Nhân viên phê duyệt")]
        public EmployeeVM NhanVienPheDuyet { get; set; }
        [DisplayName("Tình trạng phê duyệt")]
        public string TinhTrangPheDuyet { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

    }


    public class AdminYeuCauDatLuongCoBanViewVM
    {
        [DisplayName("Tổng các yêu cầu")]
        public int TotalRequests { get; set; }
        [DisplayName("Yêu cầu được chấp thuận")]
        public int ApprovedRequets { get; set; }
        [DisplayName("Yêu cầu đang chờ")]
        public int PendingRequests { get; set; }
        [DisplayName("Yêu cầu bị từ chối")]
        public int RejectedRequests { get; set; }

        [DisplayName("Yêu cầu bị hủy")]
        public int CancelledRequests { get; set; }

        public List<YeuCauDatLuongCoBanVM> YeuCauDatLuongCoBans { get; set; }
    }



    public class EmployeeYeuCauDatLuongCoBanViewVM
    {
        public List<YeuCauDatLuongCoBanVM> YeuCauDatLuongCoBans { get; set; }

        public EmployeeVM NhanVienYeuCau { get; set; }
    }
}
