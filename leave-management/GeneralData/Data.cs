using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.GeneralData
{
    public static class Data
    {
        public enum LeaveRequestStatus
        {
            DangCho,
            DaDuocChapThuan,
            DaBiTuChoi,
            DaBiHuy,
            DaDuocThucThi
        }
        public static Dictionary<LeaveRequestStatus, string> LeaveRequestStatusString = new Dictionary<LeaveRequestStatus, string>
        {
            {LeaveRequestStatus.DangCho, "Đang chờ" },
            {LeaveRequestStatus.DaDuocChapThuan,"Đã được chấp thuận" },
            {LeaveRequestStatus.DaBiTuChoi,"Đã bị từ chối" },
            {LeaveRequestStatus.DaBiHuy,"Đã bị hủy" },
            {LeaveRequestStatus.DaDuocThucThi,"Đã được thực thi" }
        };

        public enum VaiTroTrenHeThong
        {
            NhanVien,
            NhanVienPhongNhanSu,
            KeToan,
            TruongPhong,
            TruongPhongNhanSu,
            QuanTriVien
        }

        public static Dictionary<VaiTroTrenHeThong, string> VaiTroTrenHeThongString = new Dictionary<VaiTroTrenHeThong, string>
        {
            {VaiTroTrenHeThong.NhanVien,"Nhân viên" },
            {VaiTroTrenHeThong.NhanVienPhongNhanSu,"Nhân viên phòng nhân sự" },
            {VaiTroTrenHeThong.KeToan,"Kế toán" },
            {VaiTroTrenHeThong.TruongPhong,"Trưởng phòng" },
            {VaiTroTrenHeThong.TruongPhongNhanSu,"Trưởng phòng nhân sự" },
            {VaiTroTrenHeThong.QuanTriVien,"Quản trị viên" }
        };

        public enum PhieuChiStatus
        {
            DaChiTien,
            ChuaChiTien,
            DaBiThuHoi,
            KhongTonTai
        }

        public static Dictionary<PhieuChiStatus, string> PhieuChiStatusString = new Dictionary<PhieuChiStatus, string>
        {
            {PhieuChiStatus.DaChiTien, "Đã chi tiền" },
            {PhieuChiStatus.ChuaChiTien,"Chưa chi tiền" },
            {PhieuChiStatus.DaBiThuHoi,"Đã bị thu hồi" },
            {PhieuChiStatus.KhongTonTai,"Không tồn tại" },
        };

        public enum YeuCauDatLuongCoBanStatus
        {
            DangCho,
            DaDuocChapThuan,
            DaBiTuChoi,
            DaBiHuy
        }
        public static Dictionary<YeuCauDatLuongCoBanStatus, string> YeuCauDatLuongCoBanStatusString = new Dictionary<YeuCauDatLuongCoBanStatus, string>
        {
            {YeuCauDatLuongCoBanStatus.DangCho, "Đang chờ" },
            {YeuCauDatLuongCoBanStatus.DaDuocChapThuan,"Đã được chấp thuận" },
            {YeuCauDatLuongCoBanStatus.DaBiTuChoi,"Đã bị từ chối" },
            {YeuCauDatLuongCoBanStatus.DaBiHuy,"Đã bị hủy" }
        };


        public enum YeuCauTamUngLuongStatus
        {
            DangCho,
            DaDuocChapThuan,
            DaBiTuChoi,
            DaBiHuy
        }
        public static Dictionary<YeuCauTamUngLuongStatus, string> YeuCauTamUngLuongStatusString = new Dictionary<YeuCauTamUngLuongStatus, string>
        {
            {YeuCauTamUngLuongStatus.DangCho, "Đang chờ" },
            {YeuCauTamUngLuongStatus.DaDuocChapThuan,"Đã được chấp thuận" },
            {YeuCauTamUngLuongStatus.DaBiTuChoi,"Đã bị từ chối" },
            {YeuCauTamUngLuongStatus.DaBiHuy,"Đã bị hủy" }
        };
    }


    
      
    
    
}
