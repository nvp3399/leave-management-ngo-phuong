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
            Administrator
        }

        public static Dictionary<VaiTroTrenHeThong, string> VaiTroTrenHeThongString = new Dictionary<VaiTroTrenHeThong, string>
        {
            {VaiTroTrenHeThong.NhanVien,"Nhân viên" },
            {VaiTroTrenHeThong.NhanVienPhongNhanSu,"Nhân viên phòng nhân sự" },
            {VaiTroTrenHeThong.KeToan,"Kế toán" },
            {VaiTroTrenHeThong.TruongPhong,"Trưởng phòng" },
            {VaiTroTrenHeThong.TruongPhongNhanSu,"Trưởng phòng nhân sự" },
            {VaiTroTrenHeThong.Administrator,"Administrator" }
        };

        public enum PhieuChiStatus
        {
            DaChiTien,
            ChuaChiTien,
            DaBiThuHoi
        }

        public static Dictionary<PhieuChiStatus, string> PhieuChiStatusString = new Dictionary<PhieuChiStatus, string>
        {
            {PhieuChiStatus.DaChiTien, "Đã chi tiền" },
            {PhieuChiStatus.ChuaChiTien,"Chưa chi tiền" },
            {PhieuChiStatus.DaBiThuHoi,"Đã bị thu hồi" }
        };

    }


    
      
    
    
}
