using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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


        public static PhieuChi_LuongCuoiThangVM FeedSomeDataToPhieuChi_LuongCuoiThangModel(IMapper mapper, 
            IPhieuChi_LuongCuoiThangRepository phieuChi_LuongCuoiThangRepository, 
            INhatKylamViecRepository nhatKylamViecRepository,
            IPhieuChi_NKLVRepository phieuChi_NKLVRepository,
            UserManager<Employee> userManager,
            ClaimsPrincipal User,
            string maPhieuChi)
        {
            var phieuChiLuongCuoiThang =  phieuChi_LuongCuoiThangRepository.FindById(maPhieuChi).Result;
            var model = mapper.Map<PhieuChi_LuongCuoiThangVM>(phieuChiLuongCuoiThang);
            //var maNhanVienDuocXuatLuong = await phieuChi_NKLVRepository.FindMaNhanVienByMaPhieuChi(model.MaPhieuChi);
            var phieuchi_nklv = ( phieuChi_NKLVRepository.FindAll().Result)
                .FirstOrDefault(q => q.MaPhieuChi == model.MaPhieuChi);
            var thoiGianTinhLuong = phieuchi_nklv.ThoiGianBatDau_NKLV;
            var maNhanVienDuocChiTien = phieuchi_nklv.MaNhanVien_NKLV;

            int tongSoPhutLamViec = TinhTongSoPhutLamDaTichLuyTrongThang(
                nhatKylamViecRepository,
                maNhanVienDuocChiTien,
                thoiGianTinhLuong.Year,
                thoiGianTinhLuong.Month);

            model.TongSoGioLam = new TongSoGioLam();
            model.TongSoGioLam.SoGio = tongSoPhutLamViec / 60;
            model.TongSoGioLam.SoPhut = tongSoPhutLamViec % 60;

            model.TongTienLuongCoBanDaTichLuyTrongThang =
                TinhTongLuongCoBanTichLuyTrongThang(
                    nhatKylamViecRepository,
                maNhanVienDuocChiTien,
                thoiGianTinhLuong.Year,
                thoiGianTinhLuong.Month);

            model.TongTienThuongDaTichLuyTrongThang =
                TinhTongTienThuongDaTichLuyTrongThang(
                    nhatKylamViecRepository,
                maNhanVienDuocChiTien,
                thoiGianTinhLuong.Year,
                thoiGianTinhLuong.Month);

            model.TongTienLuong = model.TongTienLuongCoBanDaTichLuyTrongThang + model.TongTienThuongDaTichLuyTrongThang;

            model.NhanVienDuocChiTien = mapper.Map<EmployeeVM>( userManager.FindByIdAsync(maNhanVienDuocChiTien).Result);
            model.NhanVienXuatLuong = mapper.Map<EmployeeVM>( userManager.FindByIdAsync(model.MaNhanVienXuatLuong).Result);
            model.NhanVienChiTien = mapper.Map<EmployeeVM>( userManager.GetUserAsync(User).Result);
            return model;
        }
        public static PhieuChi_TamUngLuongVM FeedSomeDataToPhieuChi_TamUngLuongVM(
            IPhieuChi_TamUngLuongRepository phieuChi_TamUngLuongRepository,
            IMapper mapper,
            IYeuCauTamUngLuongRepository yeuCauTamUngLuongRepository,
             UserManager<Employee> userManager,
            ClaimsPrincipal User,
            string maPhieuChi)
        {
            var phieuChiTamUngLuong =  phieuChi_TamUngLuongRepository.FindById(maPhieuChi).Result;
            var yeuCauTamUngLuong =  yeuCauTamUngLuongRepository.FindById(phieuChiTamUngLuong.MaYeuCauTamUngLuong).Result;
            phieuChiTamUngLuong.YeuCauTamUngLuong = yeuCauTamUngLuong;

            var model = mapper.Map<PhieuChi_TamUngLuongVM>(phieuChiTamUngLuong);
            model.NhanVienDuocChiTien = mapper.Map<EmployeeVM>( userManager.FindByIdAsync(yeuCauTamUngLuong.MaNhanVienGuiYeuCau).Result);
            model.NhanVienXuatPhieuChi = mapper.Map<EmployeeVM>( userManager.FindByIdAsync(yeuCauTamUngLuong.MaNhanVienPheDuyet).Result);
            model.NhanVienChiTien = mapper.Map<EmployeeVM>( userManager.GetUserAsync(User).Result);

            return model;
        }
    }
}
