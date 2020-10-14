﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using leave_management.Data;

namespace leave_management.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201014091219_TableNhatKyLamViecAdd2Properties")]
    partial class TableNhatKyLamViecAdd2Properties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("leave_management.Data.DanhMucChucVu", b =>
                {
                    b.Property<string>("MaChucVu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChucVu");

                    b.ToTable("DanhMucChucVus");
                });

            modelBuilder.Entity("leave_management.Data.DanhMucChuyenMon", b =>
                {
                    b.Property<string>("MaChuyenMon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChuyenMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChuyenMon");

                    b.ToTable("DanhMucChuyenMons");
                });

            modelBuilder.Entity("leave_management.Data.DanhMucPhongBan", b =>
                {
                    b.Property<string>("MaPhongBan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenPhongBan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhongBan");

                    b.ToTable("DanhMucPhongBans");
                });

            modelBuilder.Entity("leave_management.Data.GiayToTuyThan", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaLoaiGiayTo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNhanVienGui")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayLuuVaoHeThong")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViTriLuuBanScan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien", "MaLoaiGiayTo");

                    b.HasIndex("MaLoaiGiayTo");

                    b.HasIndex("MaNhanVienGui");

                    b.ToTable("GiayToTuyThans");
                });

            modelBuilder.Entity("leave_management.Data.HopDongLaoDong", b =>
                {
                    b.Property<string>("MaHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaMauHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienChinhSuaLanCuoi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienChuTheHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienGuiBanScan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienHuyHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayGuiBanScan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayHopDongBiHuy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKyKet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianChinhSuaLanCuoi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViTriLuuBanScan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHopDong");

                    b.HasIndex("MaMauHopDong");

                    b.HasIndex("MaNhanVienChinhSuaLanCuoi");

                    b.HasIndex("MaNhanVienChuTheHopDong");

                    b.HasIndex("MaNhanVienGuiBanScan");

                    b.HasIndex("MaNhanVienHuyHopDong");

                    b.ToTable("HopDongLaoDongs");
                });

            modelBuilder.Entity("leave_management.Data.LeaveAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("int");

                    b.Property<string>("MaNhanVienPhanBo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LeaveTypeId");

                    b.HasIndex("MaNhanVienPhanBo");

                    b.ToTable("LeaveAllocations");
                });

            modelBuilder.Entity("leave_management.Data.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ApprovedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateActioned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("int");

                    b.Property<string>("RequestingEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("LeaveTypeId");

                    b.HasIndex("RequestingEmployeeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("leave_management.Data.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultDays")
                        .HasColumnType("int");

                    b.Property<string>("MaNhanVienTao")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaNhanVienTao");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("leave_management.Data.LoaiGiayToTuyThan", b =>
                {
                    b.Property<string>("MaLoaiGiayTo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoaiGiayTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiGiayTo");

                    b.ToTable("LoaiGiayToTuyThans");
                });

            modelBuilder.Entity("leave_management.Data.LoaiHopDong", b =>
                {
                    b.Property<string>("MaLoaiHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiHopDong");

                    b.ToTable("LoaiHopDongs");
                });

            modelBuilder.Entity("leave_management.Data.LoaiLichBieu", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("HeSoLuongCoBan")
                        .HasColumnType("real");

                    b.Property<string>("TenLoaiLichBieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoai");

                    b.ToTable("LoaiLichBieus");
                });

            modelBuilder.Entity("leave_management.Data.LuongTheoThang", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Nam")
                        .HasColumnType("int");

                    b.Property<byte>("Thang")
                        .HasColumnType("tinyint");

                    b.Property<int>("SoTienPhuCap")
                        .HasColumnType("int");

                    b.Property<int>("SoTienThuongThem")
                        .HasColumnType("int");

                    b.Property<int>("TongLuongCoBan")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThaiXuatLuong")
                        .HasColumnType("bit");

                    b.HasKey("MaNhanVien", "Nam", "Thang");

                    b.ToTable("LuongTheoThangs");
                });

            modelBuilder.Entity("leave_management.Data.MauHopDong", b =>
                {
                    b.Property<string>("MaMauHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaLoaiHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienChinhSuaLanCuoi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienLuuMauHopDong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayGuiMauHopDong")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenMauHopDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianChinhSuaLanCuoi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViTriLuuMauHopDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaMauHopDong");

                    b.HasIndex("MaLoaiHopDong");

                    b.HasIndex("MaNhanVienChinhSuaLanCuoi");

                    b.HasIndex("MaNhanVienLuuMauHopDong");

                    b.ToTable("MauHopDongs");
                });

            modelBuilder.Entity("leave_management.Data.NhatKyLamViec", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaLoaiLichBieu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienThemVaoHeThong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayThemVaoHeThong")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoTienThuongThem")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("MaNhanVien", "ThoiGianBatDau");

                    b.HasIndex("MaLoaiLichBieu");

                    b.HasIndex("MaNhanVienThemVaoHeThong");

                    b.ToTable("NhatKyLamViecs");
                });

            modelBuilder.Entity("leave_management.Data.PhieuChi", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ThoiGianXuatPhieuChi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LyDoChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNhanVienChiTien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienXuatPhieu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NamTinhLuong")
                        .HasColumnType("int");

                    b.Property<int>("SoTienChi")
                        .HasColumnType("int");

                    b.Property<byte>("ThangTinhLuong")
                        .HasColumnType("tinyint");

                    b.Property<string>("TrangThaiPhieuChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien", "ThoiGianXuatPhieuChi");

                    b.HasIndex("MaNhanVienChiTien");

                    b.HasIndex("MaNhanVienXuatPhieu");

                    b.ToTable("PhieuChis");
                });

            modelBuilder.Entity("leave_management.Data.YeuCauDatLuongCoBan", b =>
                {
                    b.Property<string>("MaYeuCau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNhanVienDuocDatLuong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienGuiYeuCau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienPheDuyet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MucLuongCoBan")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianGuiYeuCau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianPheDuyet")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrangPheDuyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaYeuCau");

                    b.HasIndex("MaNhanVienDuocDatLuong");

                    b.HasIndex("MaNhanVienGuiYeuCau");

                    b.HasIndex("MaNhanVienPheDuyet");

                    b.ToTable("YeuCauDatLuongCoBans");
                });

            modelBuilder.Entity("leave_management.Data.YeuCauTamUngLuong", b =>
                {
                    b.Property<string>("MaYeuCau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNhanVienGuiYeuCau")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienPheDuyet")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayGuiYeuCau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayPheDuyet")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoTienTamUng")
                        .HasColumnType("int");

                    b.Property<string>("TinhTrangPheDuyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaYeuCau");

                    b.HasIndex("MaNhanVienGuiYeuCau");

                    b.HasIndex("MaNhanVienPheDuyet");

                    b.ToTable("YeuCauTamUngLuongs");
                });

            modelBuilder.Entity("leave_management.Data.Employee", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaChiLienLac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiTamTru")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaChucVu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaChuyenMon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVienThemVaoHeThong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaPhongBan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSoThue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MucLuongCoBan")
                        .HasColumnType("int");

                    b.Property<string>("NoiSinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoCMND")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ViTriLuuAnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("MaChucVu");

                    b.HasIndex("MaChuyenMon");

                    b.HasIndex("MaNhanVienThemVaoHeThong");

                    b.HasIndex("MaPhongBan");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("leave_management.Data.GiayToTuyThan", b =>
                {
                    b.HasOne("leave_management.Data.LoaiGiayToTuyThan", "LoaiGiayTo")
                        .WithMany()
                        .HasForeignKey("MaLoaiGiayTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "NhanVienGui")
                        .WithMany()
                        .HasForeignKey("MaNhanVienGui");
                });

            modelBuilder.Entity("leave_management.Data.HopDongLaoDong", b =>
                {
                    b.HasOne("leave_management.Data.MauHopDong", "MauHopDong")
                        .WithMany()
                        .HasForeignKey("MaMauHopDong");

                    b.HasOne("leave_management.Data.Employee", "NhanVienChinhSuaLanCuoi")
                        .WithMany()
                        .HasForeignKey("MaNhanVienChinhSuaLanCuoi");

                    b.HasOne("leave_management.Data.Employee", "NhanVienChuTheHopDong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienChuTheHopDong");

                    b.HasOne("leave_management.Data.Employee", "NhanVienGuiBanScan")
                        .WithMany()
                        .HasForeignKey("MaNhanVienGuiBanScan");

                    b.HasOne("leave_management.Data.Employee", "NhanVienHuyHopDong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienHuyHopDong");
                });

            modelBuilder.Entity("leave_management.Data.LeaveAllocation", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("leave_management.Data.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("LeaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "NhanVienPhanBo")
                        .WithMany()
                        .HasForeignKey("MaNhanVienPhanBo");
                });

            modelBuilder.Entity("leave_management.Data.LeaveRequest", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "ApproveBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.HasOne("leave_management.Data.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("LeaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "RequestingEmployee")
                        .WithMany()
                        .HasForeignKey("RequestingEmployeeId");
                });

            modelBuilder.Entity("leave_management.Data.LeaveType", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "NhanVienTao")
                        .WithMany()
                        .HasForeignKey("MaNhanVienTao");
                });

            modelBuilder.Entity("leave_management.Data.LuongTheoThang", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("leave_management.Data.MauHopDong", b =>
                {
                    b.HasOne("leave_management.Data.LoaiHopDong", "LoaiHopDong")
                        .WithMany()
                        .HasForeignKey("MaLoaiHopDong");

                    b.HasOne("leave_management.Data.Employee", "NhanVienChinhSuaLanCuoi")
                        .WithMany()
                        .HasForeignKey("MaNhanVienChinhSuaLanCuoi");

                    b.HasOne("leave_management.Data.Employee", "NhanVienLuuMauHopDong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienLuuMauHopDong");
                });

            modelBuilder.Entity("leave_management.Data.NhatKyLamViec", b =>
                {
                    b.HasOne("leave_management.Data.LoaiLichBieu", "LoaiLichBieu")
                        .WithMany()
                        .HasForeignKey("MaLoaiLichBieu");

                    b.HasOne("leave_management.Data.Employee", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "NhanVienThemVaoHeThong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienThemVaoHeThong");
                });

            modelBuilder.Entity("leave_management.Data.PhieuChi", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("leave_management.Data.Employee", "NhanVienChiTien")
                        .WithMany()
                        .HasForeignKey("MaNhanVienChiTien");

                    b.HasOne("leave_management.Data.Employee", "NhanVienXuatPhieu")
                        .WithMany()
                        .HasForeignKey("MaNhanVienXuatPhieu");
                });

            modelBuilder.Entity("leave_management.Data.YeuCauDatLuongCoBan", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "NhanVienDuocDatLuong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienDuocDatLuong");

                    b.HasOne("leave_management.Data.Employee", "NhanVienGuiYeuCau")
                        .WithMany()
                        .HasForeignKey("MaNhanVienGuiYeuCau");

                    b.HasOne("leave_management.Data.Employee", "NhanVienPheDuyet")
                        .WithMany()
                        .HasForeignKey("MaNhanVienPheDuyet");
                });

            modelBuilder.Entity("leave_management.Data.YeuCauTamUngLuong", b =>
                {
                    b.HasOne("leave_management.Data.Employee", "NhanVienGuiYeuCau")
                        .WithMany()
                        .HasForeignKey("MaNhanVienGuiYeuCau");

                    b.HasOne("leave_management.Data.Employee", "NhanVienPheDuyet")
                        .WithMany()
                        .HasForeignKey("MaNhanVienPheDuyet");
                });

            modelBuilder.Entity("leave_management.Data.Employee", b =>
                {
                    b.HasOne("leave_management.Data.DanhMucChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("MaChucVu");

                    b.HasOne("leave_management.Data.DanhMucChuyenMon", "ChuyenMon")
                        .WithMany()
                        .HasForeignKey("MaChuyenMon");

                    b.HasOne("leave_management.Data.Employee", "NhanVienThemVaoHeThong")
                        .WithMany()
                        .HasForeignKey("MaNhanVienThemVaoHeThong");

                    b.HasOne("leave_management.Data.DanhMucPhongBan", "PhongBan")
                        .WithMany()
                        .HasForeignKey("MaPhongBan");
                });
#pragma warning restore 612, 618
        }
    }
}
