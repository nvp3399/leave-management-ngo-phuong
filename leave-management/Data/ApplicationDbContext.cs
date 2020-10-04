using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<DanhMucChucVu> DanhSachDanhMucChucVu { get; set; }
        public DbSet<DanhMucChuyenMon> DanhSachDanhMucChuyenMon { get; set; }

        public DbSet<DanhMucPhongBan> DanhSachDanhMucPhongBan { get; set; }
        public DbSet<GiayToTuyThan> DanhSachGiayToTuyThan { get; set; }
        public DbSet<HopDongLaoDong> DanhSachHopDongLaoDong { get; set; }
        public DbSet<LoaiGiayToTuyThan> DanhSachLoaiGiayToTuyThan { get; set; }
        public DbSet<LoaiHopDong> DanhSachLoaiHopDong { get; set; }
        public DbSet<LoaiLichBieu> DanhSachLoaiLichBieu { get; set; }
        public DbSet<LuongTheoThang> DanhSachLuongTheoThang { get; set; }
        public DbSet<MauHopDong> DanhSachMauHopDong { get; set; }
        public DbSet<NhatKyLamViec> DanhSachNhatKyLamViec { get; set; }
        public DbSet<PhieuChi> DanhSachPhieuChi { get; set; }
        public DbSet<YeuCauDatLuongCoBan> DanhSachYeuCauDatLuongCoBan { get; set; }
        public DbSet<YeuCauTamUngLuong> DanhSachYeuCauTamUngLuong { get; set; }

    }
}
