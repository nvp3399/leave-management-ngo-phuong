using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static leave_management.Functions.Functions;

namespace leave_management.Controllers
{
    public class ChiTienController : Controller
    {
        private readonly ILeaveTypeRepository leaverepo;
        private readonly ILeaveAllocationRepository leaveallocationrepo;
        private readonly IMapper mapper;
        private readonly UserManager<Employee> userManager;
        private readonly IChucVuRepository chucVuRepo;
        private readonly IChuyenMonRepository chuyenMonRepo;
        private readonly IPhongBanRepository phongBanRepo;
        private readonly IRoleRepository roleRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly INhatKylamViecRepository nhatKylamViecRepository;
        private readonly IPhieuChi_LuongCuoiThangRepository phieuChi_LuongCuoiThangRepository;
        private readonly IPhieuChi_NKLVRepository phieuChi_NKLVRepository;
        private readonly IPhieuChi_TamUngLuongRepository phieuChi_TamUngLuongRepository;
        private readonly IYeuCauTamUngLuongRepository yeuCauTamUngLuongRepository;

        public ChiTienController(ILeaveTypeRepository leaverepo,
            ILeaveAllocationRepository leaveallocationrepo,
            IMapper mapper,
            UserManager<Employee> userManager,
            IChucVuRepository chucVuRepo,
            IChuyenMonRepository chuyenMonRepo,
            IPhongBanRepository phongBanRepo,
            IRoleRepository roleRepository,
            IWebHostEnvironment hostEnvironment,
            IUserRoleRepository userRoleRepository,
            INhatKylamViecRepository nhatKylamViecRepository,
            IPhieuChi_LuongCuoiThangRepository phieuChi_LuongCuoiThangRepository,
            IPhieuChi_NKLVRepository phieuChi_NKLVRepository,
            IPhieuChi_TamUngLuongRepository phieuChi_TamUngLuongRepository,
            IYeuCauTamUngLuongRepository yeuCauTamUngLuongRepository
            )
        {
            this.leaverepo = leaverepo;
            this.leaveallocationrepo = leaveallocationrepo;
            this.mapper = mapper;
            this.userManager = userManager;

            this.chucVuRepo = chucVuRepo;
            this.chuyenMonRepo = chuyenMonRepo;
            this.roleRepository = roleRepository;
            webHostEnvironment = hostEnvironment;
            this.userRoleRepository = userRoleRepository;
            this.nhatKylamViecRepository = nhatKylamViecRepository;
            this.phieuChi_LuongCuoiThangRepository = phieuChi_LuongCuoiThangRepository;
            this.phieuChi_NKLVRepository = phieuChi_NKLVRepository;
            this.phieuChi_TamUngLuongRepository = phieuChi_TamUngLuongRepository;
            this.yeuCauTamUngLuongRepository = yeuCauTamUngLuongRepository;
            this.phongBanRepo = phongBanRepo;
        }
        // GET: PhieuChiController
        public async Task<ActionResult> Index()
        {
            var phieuchi_luongCuoiThangs = mapper.Map<ICollection<PhieuChi_LuongCuoiThangVM>>(await phieuChi_LuongCuoiThangRepository.FindAll());
            var phieuchi_tamUngLuongs = mapper.Map<ICollection<PhieuChi_TamUngLuongVM>>(await phieuChi_TamUngLuongRepository.FindAll());

            foreach (var phieuchi_tamung in phieuchi_tamUngLuongs)
            {
                var yeuCauTamUngLuong = await yeuCauTamUngLuongRepository.FindById(phieuchi_tamung.MaYeuCauTamUngLuong);
                var nhanVienGuiYeuCauTamUng = yeuCauTamUngLuong.NhanVienGuiYeuCau;
                phieuchi_tamung.NhanVienDuocChiTien = mapper.Map<EmployeeVM>(nhanVienGuiYeuCauTamUng);

                var nhanVienXuatPhieuChi = yeuCauTamUngLuong.NhanVienPheDuyet;
                phieuchi_tamung.NhanVienXuatPhieuChi = mapper.Map<EmployeeVM>(nhanVienXuatPhieuChi);

                phieuchi_tamung.ThoiGianXuatPhieuChi = yeuCauTamUngLuong.NgayPheDuyet;

            }

            foreach (var phieuChi_LuongCuoiThang in phieuchi_luongCuoiThangs)
            {
                var maNhanVienDuocChiTien = await phieuChi_NKLVRepository.FindMaNhanVienByMaPhieuChi(phieuChi_LuongCuoiThang.MaPhieuChi);
                if (maNhanVienDuocChiTien == null)
                {

                    throw new Exception("Lỗi ở dòng 93, đọc note bên dưới");
                    // Lỗi xảy ra do phiếu chi - lương cuối tháng đã được xuất nhưng quan hệ giữa phieuchi_luongcuoithang và nhatkylamviec vẫn
                    // chưa được lưu vào bảng phieuchi_nklvs. 
                }

                var nhanVienDuocChiTien = await userManager.FindByIdAsync(maNhanVienDuocChiTien);

                phieuChi_LuongCuoiThang.NhanVienDuocChiTien = mapper.Map<EmployeeVM>(nhanVienDuocChiTien);
            }

            var model = new PhieuChiListVM
            {
                PhieuChi_LuongCuoiThangs = phieuchi_luongCuoiThangs,
                PhieuChi_TamUngLuongs = phieuchi_tamUngLuongs
            };
            return View(model);
        }

        // GET: PhieuChiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhieuChiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuChiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuChiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhieuChiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> XacNhanChiTien(string id)
        {
            var phieuchi_luongCuoiThang = await phieuChi_LuongCuoiThangRepository.FindById(id);
            var phieuchi_tamUngLuong = await phieuChi_TamUngLuongRepository.FindById(id);
            if (phieuchi_luongCuoiThang != null)
            {
                phieuchi_luongCuoiThang.MaNhanVienChiTien = userManager.GetUserAsync(User).Result.Id;
                phieuchi_luongCuoiThang.ThoiGianChiTien = DateTime.Now;
                var isSuccess = await phieuChi_LuongCuoiThangRepository.Update(phieuchi_luongCuoiThang);
            }
            else if (phieuchi_tamUngLuong != null)
            {
                phieuchi_tamUngLuong.MaNhanVienChiTien = userManager.GetUserAsync(User).Result.Id;
                phieuchi_tamUngLuong.ThoiGianChiTien = DateTime.Now;
                var isSuccess = await phieuChi_TamUngLuongRepository.Update(phieuchi_tamUngLuong);
            }
            else
            {
                throw new Exception("Không tìm thấy phiếu chi");
            }
            return RedirectToAction(nameof(Index));
        }

        //public async Task<ActionResult> ChiTienView(string id)
        //{
        //    var phieuchi_luongCuoiThang = await phieuChi_LuongCuoiThangRepository.FindById(id);
        //    var phieuchi_tamUngLuong = await phieuChi_TamUngLuongRepository.FindById(id);

        //    var model = new XuatLuongVM();

        //    if (phieuchi_luongCuoiThang != null)
        //    {
        //        return await ChiTienLuongCuoiThang(id);
        //    }
        //    else if (phieuchi_tamUngLuong != null)
        //    {
        //        return await ChiTienTamUngLuong(id);
        //    }
        //    else
        //    {
        //        throw new Exception("Không tìm thấy phiếu chi");
        //    }

        //}

        public async Task<ActionResult> ChiTienLuongCuoiThang(string id)
        {// id = ma phieu chi luong cuoi thang
            var phieuChiLuongCuoiThang = await phieuChi_LuongCuoiThangRepository.FindById(id);
            var model = mapper.Map<PhieuChi_LuongCuoiThangVM>(phieuChiLuongCuoiThang);
            //var maNhanVienDuocXuatLuong = await phieuChi_NKLVRepository.FindMaNhanVienByMaPhieuChi(model.MaPhieuChi);
            var phieuchi_nklv = (await phieuChi_NKLVRepository.FindAll())
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

            model.NhanVienDuocChiTien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(maNhanVienDuocChiTien));
            model.NhanVienXuatLuong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVienXuatLuong));
            model.NhanVienChiTien = mapper.Map<EmployeeVM>(await userManager.GetUserAsync(User));
            return View(model);

        }

        public async Task<ActionResult> ChiTienTamUngLuong(string id)
        {//id = ma phieu chi luong tam ung
            var phieuChiTamUngLuong = await phieuChi_TamUngLuongRepository.FindById(id);
            var yeuCauTamUngLuong = await yeuCauTamUngLuongRepository.FindById(phieuChiTamUngLuong.MaYeuCauTamUngLuong);
            phieuChiTamUngLuong.YeuCauTamUngLuong = yeuCauTamUngLuong;

            var model = mapper.Map<PhieuChi_TamUngLuongVM>(phieuChiTamUngLuong);
            model.NhanVienDuocChiTien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(yeuCauTamUngLuong.MaNhanVienGuiYeuCau));
            model.NhanVienXuatPhieuChi = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(yeuCauTamUngLuong.MaNhanVienPheDuyet));
            model.NhanVienChiTien = mapper.Map<EmployeeVM>(await userManager.GetUserAsync(User));

            return View(model);
        }




        // POST: PhieuChiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
