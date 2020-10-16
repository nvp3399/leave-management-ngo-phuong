using System;
using System.Collections.Generic;
using System.Linq;
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

namespace leave_management.Controllers
{
    public class XuatLuongCuoiThangController : Controller
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

        public XuatLuongCuoiThangController(ILeaveTypeRepository leaverepo,
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
            IPhieuChi_NKLVRepository phieuChi_NKLVRepository
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
            this.phongBanRepo = phongBanRepo;
        }

        // GET: XuatLuongCuoiThang
        // GET: ChamCongController
        public async Task<ActionResult> Index()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            var model = await FeedSomeDataToIndexAction(month, year);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ChamCongVMListViewForm viewForm)
        {
            int year = int.Parse(viewForm.CurrentYear);
            int month = int.Parse(viewForm.CurrentMonth);

            var model = await FeedSomeDataToIndexAction(month, year);


            return View(model);
        }

        private async Task<ChamCongVMList> FeedSomeDataToIndexAction(int month, int year)
        {
            var employees = await userManager.Users.ToListAsync();

            var chamCongVMList = mapper.Map<List<ChamCongVM>>(employees);


            foreach (var employee in chamCongVMList)
            {
                employee.ChucVu = mapper.Map<ChucVusVM>(await chucVuRepo.FindById(employee.MaChucVu));
                employee.ChuyenMon = mapper.Map<ChuyenMonsVM>(await chuyenMonRepo.FindById(employee.MaChuyenMon));
                employee.PhongBan = mapper.Map<PhongBansVM>(await phongBanRepo.FindById(employee.MaPhongBan));
                var MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
                employee.VaiTroTrenHeThong = await roleRepository.FindById(MaVaiTroTrenHeThong);
                //Tiền lương đã tích lũy = lương cơ bản /(6 ngày * 4 tuần *24 giờ* 60 phút)*hệ số lương * số phút của lịch biểu
                employee.TongTienLuongCoBanDaTichLuyTrongThang = TinhTongLuongCoBanTichLuyTrongThang(employee.Id, year, month);
                employee.TongTienThuongDaTichLuyTrongThang = TinhTongTienThuongDaTichLuyTrongThang(employee.Id, year, month);

                int tongSoPhut = TinhTongSoPhutLamDaTichLuyTrongThang(employee.Id, year, month);
                employee.TongSoGio.SoGio = tongSoPhut / 60;
                employee.TongSoGio.SoPhut = tongSoPhut % 60;

                employee.TongTienLuong = employee.TongTienLuongCoBanDaTichLuyTrongThang + employee.TongTienThuongDaTichLuyTrongThang;
                employee.TrangThaiXuatLuong = (await phieuChi_NKLVRepository.DaXuatPhieuChiHayChua(employee.Id, month, year));
            }

            var model = new ChamCongVMList
            {
                ChamCongList = chamCongVMList,
                ViewForm = new ChamCongVMListViewForm
                {
                    CurrentMonth = month.ToString(),
                    CurrentYear = year.ToString()
                }
            };
            model = FeedSomeDataToChamCongVMList(model);
            return model;
        }

        private ChamCongVMList FeedSomeDataToChamCongVMList(ChamCongVMList model)
        {


            var years = new List<SelectListItem>();
            for (int i = 2010; i < 2031; i++)
            {
                years.Add(new SelectListItem
                {
                    Text = "Năm " + i,
                    Value = i.ToString()
                });

            }


            var months = new List<SelectListItem>();
            for (int i = 1; i < 13; i++)
            {
                months.Add(new SelectListItem
                {
                    Text = "Tháng " + i,
                    Value = i.ToString()
                });
            }

            model.Years = years;
            model.MonthsInYear = months;

            return model;
        }


        private int TinhTongSoPhutLamDaTichLuyTrongThang(string employeeId, int year, int month)
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


        private int TinhTongLuongCoBanTichLuyTrongThang(string employeeId, int year, int month)
        {
            //Tiền lương đã tích lũy = lương cơ bản /(6 ngày * 4 tuần *8 giờ* 60 phút)*hệ số lương * số phút của lịch biểu
            var nhatKyLamViecs =  nhatKylamViecRepository.FindByMaNhanVienAndThangTinhLuong(employeeId, month, year).Result;

            int tongSoTien = 0;
            foreach (var nhatKy in nhatKyLamViecs)
            {
                int soPhut = (int)(nhatKy.ThoiGianKetThuc - nhatKy.ThoiGianBatDau).TotalMinutes;
                tongSoTien += (int)(nhatKy.MucLuongCoBan / (6 * 4 * 8 * 60) * nhatKy.HeSoLuongCoBan * soPhut);
            }

            return tongSoTien;
        }

        private int TinhTongTienThuongDaTichLuyTrongThang(string employeeId, int year, int month)
        {
            var nhatKyLamViecs = nhatKylamViecRepository.FindByMaNhanVienAndThangTinhLuong(employeeId, month, year).Result;

            int tongSoTien = 0;
            foreach (var nhatKy in nhatKyLamViecs)
            {
                tongSoTien += nhatKy.SoTienThuongThem;
            }

            return tongSoTien;
        }

        public async Task<ActionResult> XuatLuong(string maNhanVienDuocXuatLuong, string selectedMonth, string selectedYear)
        {
            int year = int.Parse(selectedYear);
            int month = int.Parse(selectedMonth);
            var model = new XuatLuongCuoiThangVM
            {
                TongTienLuongCoBan = TinhTongLuongCoBanTichLuyTrongThang(maNhanVienDuocXuatLuong, year, month),
                TongTienThuong = TinhTongTienThuongDaTichLuyTrongThang(maNhanVienDuocXuatLuong, year, month),
                

                NhanVienDuocXuatLuong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(maNhanVienDuocXuatLuong)),
                NhanVienXuatLuong = mapper.Map<EmployeeVM>(await userManager.GetUserAsync(User)),
                NamTinhLuong = year,
                ThangTinhLuong = month
            };
            int tongSoPhut = TinhTongSoPhutLamDaTichLuyTrongThang(maNhanVienDuocXuatLuong, year, month);
            model.TongSoGio = new TongSoGioLam();

            model.TongSoGio.SoGio = tongSoPhut / 60;
            model.TongSoGio.SoPhut = tongSoPhut % 60;
            

                 
            model.TongTienLuong = model.TongTienLuongCoBan + model.TongTienThuong;
            model.MaNhanVienDuocXuatLuong = maNhanVienDuocXuatLuong;
            model.MaNhanVienXuatLuong = model.NhanVienXuatLuong.Id;
            model.TrangThaiXuatLuong = (await phieuChi_NKLVRepository.DaXuatPhieuChiHayChua(maNhanVienDuocXuatLuong,month,year));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> XuatLuong(XuatLuongCuoiThangVM model)
        {
            
            var phieuChi_luongCuoiThang = new PhieuChi_LuongCuoiThang
            {
                MaPhieuChi = Guid.NewGuid().ToString(),
                MaNhanVienXuatLuong = model.MaNhanVienXuatLuong,
                ThoiGianXuatPhieuChi = DateTime.Now

            };
            bool isCreatedSuccess =  await phieuChi_LuongCuoiThangRepository.Create(phieuChi_luongCuoiThang);

            if ( !isCreatedSuccess)
            {
                ModelState.AddModelError("", "Error while creating record on PhieuChi_LuongCuoiThang database table ");
                return View(model);
            }

            var nhatKyLamViecs = await nhatKylamViecRepository.FindByMaNhanVienAndThangTinhLuong(model.MaNhanVienDuocXuatLuong, model.ThangTinhLuong, model.NamTinhLuong);

            foreach (var nhatky in nhatKyLamViecs )
            {
                var phieuChi_NKLVRecord = new PhieuChi_NKLV
                {
                    MaPhieuChi = phieuChi_luongCuoiThang.MaPhieuChi,
                    MaNhanVien_NKLV = nhatky.MaNhanVien,
                    ThoiGianBatDau_NKLV = nhatky.ThoiGianBatDau,
                    ID = Guid.NewGuid().ToString()
                };
                var isCreatePhieuChi_NKLVRecordSuccess = await phieuChi_NKLVRepository.Create(phieuChi_NKLVRecord); 

                if (!isCreatePhieuChi_NKLVRecordSuccess)
                {
                    ModelState.AddModelError("", "Error while creating record on PhieuChi_NKLV database table");
                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: XuatLuongCuoiThang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: XuatLuongCuoiThang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XuatLuongCuoiThang/Create
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

        // GET: XuatLuongCuoiThang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: XuatLuongCuoiThang/Edit/5
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

        // GET: XuatLuongCuoiThang/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: XuatLuongCuoiThang/Delete/5
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
