using leave_management.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Functions
{
    public static class Functions
    {
        public static int TinhTongSoPhutLamDaTichLuyTrongThang(INhatKylamViecRepository nhatKylamViecRepository,string employeeId, int year, int month)
        {
            var nhatKyLamViecs = nhatKylamViecRepository.FindByMaNhanVien(employeeId)
                .Result
                .Where(q => q.ThoiGianBatDau.Year == year && q.ThoiGianBatDau.Month == month);

            int tongSoPhut = 0;
            foreach (var nhatKy in nhatKyLamViecs)
            {
                tongSoPhut += (int)(nhatKy.ThoiGianKetThuc - nhatKy.ThoiGianBatDau).TotalMinutes;
            }

            return tongSoPhut;
        }


        public static int TinhTongLuongCoBanTichLuyTrongThang(INhatKylamViecRepository nhatKylamViecRepository, string employeeId, int year, int month)
        {
            //Tiền lương đã tích lũy = lương cơ bản /(6 ngày * 4 tuần *8 giờ* 60 phút)*hệ số lương * số phút của lịch biểu
            var nhatKyLamViecs = nhatKylamViecRepository.FindByMaNhanVien(employeeId)
                .Result
                .Where(q => q.ThoiGianBatDau.Year == year && q.ThoiGianBatDau.Month == month);

            int tongSoTien = 0;
            foreach (var nhatKy in nhatKyLamViecs)
            {
                int soPhut = (int)(nhatKy.ThoiGianKetThuc - nhatKy.ThoiGianBatDau).TotalMinutes;
                tongSoTien += (int)((double)nhatKy.MucLuongCoBan / (6 * 4 * 8 * 60) * nhatKy.HeSoLuongCoBan * soPhut);
            }

            return tongSoTien;
        }





        public static int TinhTongTienThuongDaTichLuyTrongThang(INhatKylamViecRepository nhatKylamViecRepository, string employeeId, int year, int month)
        {
            var nhatKyLamViecs = nhatKylamViecRepository.FindByMaNhanVien(employeeId)
                .Result
                .Where(q => q.ThoiGianBatDau.Year == year && q.ThoiGianBatDau.Month == month);

            int tongSoTien = 0;
            foreach (var nhatKy in nhatKyLamViecs)
            {
                tongSoTien += nhatKy.SoTienThuongThem;
            }

            return tongSoTien;
        }
    }
}
