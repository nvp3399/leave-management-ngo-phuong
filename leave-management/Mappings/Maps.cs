using AutoMapper;
using leave_management.Data;
using leave_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, EditLeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, CreateEmployeeVM>().ReverseMap();
            CreateMap<DanhMucChucVu, ChucVusVM>().ReverseMap();
            CreateMap<DanhMucChuyenMon, ChuyenMonsVM>().ReverseMap();
            CreateMap<DanhMucPhongBan, PhongBansVM>().ReverseMap();
            CreateMap<GiayToTuyThan, GiayToTuyThanVM>().ReverseMap();
            CreateMap<HopDongLaoDong, HopDongLaoDongVM>().ReverseMap();
            CreateMap<LoaiGiayToTuyThan, LoaiGiayToTuyThanVM>().ReverseMap();
            CreateMap<LoaiHopDong, LoaiHopDongVM>().ReverseMap();
            CreateMap<LoaiLichBieu, LoaiLichBieuVM>().ReverseMap();
            CreateMap<LuongTheoThang, LuongTheoThangVM>().ReverseMap();
            CreateMap<MauHopDong, MauHopDongVM>().ReverseMap();
            CreateMap<NhatKyLamViec, LichSuChamCongVM>().ReverseMap();
            CreateMap<PhieuChi, PhieuChiVM>().ReverseMap();
            CreateMap<YeuCauDatLuongCoBan, YeuCauDatLuongCoBanVM>().ReverseMap();
            CreateMap<YeuCauTamUngLuong, YeuCauTamUngLuongVM>().ReverseMap();
            CreateMap<Employee, EditEmployeeVM>().ReverseMap();
            CreateMap<MauHopDong, CreateEditMauHopDongVM>().ReverseMap();
            CreateMap<HopDongLaoDong, HopDongLaoDongVM>().ReverseMap();
            CreateMap<HopDongLaoDong, CreateEditHopDongLaoDongVM>().ReverseMap();

            CreateMap<GiayToTuyThan, GiayToTuyThanVM>().ReverseMap();
            CreateMap<LoaiGiayToTuyThan, LoaiGiayToTuyThanVM>().ReverseMap();
            CreateMap<LoaiLichBieu, LoaiLichBieuVM>().ReverseMap();
            CreateMap<LuongTheoThang, LuongTheoThangVM>().ReverseMap();
            CreateMap<NhatKyLamViec, LichSuChamCongVM>().ReverseMap();
            CreateMap<PhieuChi, PhieuChiVM>().ReverseMap();
            CreateMap<YeuCauDatLuongCoBan, YeuCauDatLuongCoBanVM>().ReverseMap();
            CreateMap<YeuCauTamUngLuong, YeuCauTamUngLuongVM>().ReverseMap();
            CreateMap<NhatKyLamViec, CreateEditLichSuChamCongVM>().ReverseMap();
            CreateMap<Employee, ChamCongVM>().ReverseMap();
            CreateMap<GiayToTuyThan, CreateEditGiayToTuyThanVM>().ReverseMap();

            CreateMap<PhieuChi, PhieuChiVM>().ReverseMap();
            CreateMap<PhieuChi_LuongCuoiThang, PhieuChi_LuongCuoiThangVM>().ReverseMap();
            CreateMap<PhieuChi_TamUngLuong, PhieuChi_TamUngLuongVM>().ReverseMap();
            CreateMap<PhieuChi_NKLV, PhieuChi_NKLVVM>().ReverseMap();




        }
    }
}
