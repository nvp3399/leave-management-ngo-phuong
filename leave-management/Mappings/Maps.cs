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
            CreateMap<NhatKyLamViec, NhatKyLamViecVM>().ReverseMap();
            CreateMap<PhieuChi, PhieuChiVM>().ReverseMap();
            CreateMap<YeuCauDatLuongCoBan, YeuCauDatLuongCoBanVM>().ReverseMap();
            CreateMap<YeuCauTamUngLuong, YeuCauTamUngLuongVM>().ReverseMap();
            CreateMap<Employee, EditEmployeeVM>().ReverseMap();
            CreateMap<MauHopDong, CreateEditMauHopDongVM>().ReverseMap();
            CreateMap<HopDongLaoDong, HopDongLaoDongVM>().ReverseMap();
            CreateMap<HopDongLaoDong, CreateEditHopDongLaoDongVM>().ReverseMap();

        }
    }
}
