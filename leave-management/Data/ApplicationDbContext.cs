﻿using System;
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

        public DbSet<DanhMucChucVu> DanhMucChucVus { get; set; }
        public DbSet<DanhMucChuyenMon> DanhMucChuyenMons { get; set; }

        public DbSet<DanhMucPhongBan> DanhMucPhongBans { get; set; }
        public DbSet<GiayToTuyThan> GiayToTuyThans { get; set; }
        public DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }
        public DbSet<LoaiGiayToTuyThan> LoaiGiayToTuyThans { get; set; }
        public DbSet<LoaiHopDong> LoaiHopDongs { get; set; }
        public DbSet<LoaiLichBieu> LoaiLichBieus { get; set; }
        public DbSet<LuongTheoThang> LuongTheoThangs { get; set; }
        public DbSet<MauHopDong> MauHopDongs { get; set; }
        public DbSet<NhatKyLamViec> NhatKyLamViecs { get; set; }
        public DbSet<PhieuChi> PhieuChis { get; set; }
        public DbSet<YeuCauDatLuongCoBan> YeuCauDatLuongCoBans { get; set; }
        public DbSet<YeuCauTamUngLuong> YeuCauTamUngLuongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GiayToTuyThan>()
                .HasKey(c => new { c.MaNhanVien, c.MaLoaiGiayTo });

          

            modelBuilder.Entity<LuongTheoThang>()
                .HasKey(c => new { c.MaNhanVien, c.Nam, c.Thang });

            modelBuilder.Entity<PhieuChi>()
                .HasKey(c => new { c.MaNhanVien, c.ThoiGianXuatPhieuChi });

            modelBuilder.Entity<NhatKyLamViec>()
                .HasKey(c => new { c.MaNhanVien, c.ThoiGianBatDau });

            //modelBuilder.Entity<Employee>()
            //    .HasOne(emp => emp.HopDong)
            //    .WithOne(hd => hd.NhanVienChuTheHopDong);

            //modelBuilder.Entity<HopDongLaoDong>()
            //    .HasOne(hd => hd.NhanVienGuiBanScan);
                
        }

    }
}
