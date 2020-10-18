using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class YeuCauTamUngLuongVM
    {
        public string MaYeuCau { get; set; }

        [DisplayName("Nhân viên gửi yêu cầu")]
        public EmployeeVM NhanVienGuiYeuCau { get; set; }
        public string MaNhanVienGuiYeuCau { get; set; }
        [DisplayName("Ngày gửi yêu cầu")]
        public DateTime NgayGuiYeuCau { get; set; }


        public string MaNhanVienPheDuyet { get; set; }
        [DisplayName("Nhân viên phê duyệt")]
        public EmployeeVM NhanVienPheDuyet { get; set; }
        [DisplayName("Ngày phê duyệt")]
        public DateTime NgayPheDuyet { get; set; }
        [DisplayName("Số tiền tạm ứng")]
        public int SoTienTamUng { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }
        [DisplayName("Tình trạng phê duyệt")]
        public string TinhTrangPheDuyet { get; set; }

        [DisplayName("Trạng thái phiếu chi")]
        public string TrangThaiPhieuChi { get; set; }

    }


    public class AdminYeuCauTamUngLuongViewVM
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

        [DisplayName("Yêu cầu đã được chi tiền")]
        public int DaChiTienRequests { get; set; }

        public List<YeuCauTamUngLuongVM> YeuCauTamUngLuongs { get; set; }
    }



    public class EmployeeYeuCauTamUngLuongViewVM
    {
        public List<YeuCauTamUngLuongVM> YeuCauTamUngLuongs { get; set; }


        [DisplayName("Nhân viên yêu cầu: ")]
        public EmployeeVM NhanVienYeuCau { get; set; }
    }
}
