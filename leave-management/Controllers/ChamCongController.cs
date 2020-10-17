using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using leave_management.Models;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static leave_management.Functions.Functions;
using Microsoft.AspNetCore.Authorization;
using static leave_management.GeneralData.Data;

namespace leave_management.Controllers
{

    [Authorize(Roles ="Quản trị viên,Trưởng phòng,Trưởng phòng nhân sự")]

    public class ChamCongController : Controller
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
        private readonly IMauHopDongRepository mauHopDongRepository;
        private readonly IHopDongLaoDongRepository hopDongLaoDongRepository;
        private readonly INhatKylamViecRepository nhatKylamViecRepository;
        private readonly ILoaiLichBieuRepository loaiLichBieuRepository;

        public ChamCongController(ILeaveTypeRepository leaverepo,
            ILeaveAllocationRepository leaveallocationrepo,
            IMapper mapper,
            UserManager<Employee> userManager,
            IChucVuRepository chucVuRepo,
            IChuyenMonRepository chuyenMonRepo,
            IPhongBanRepository phongBanRepo,
            IRoleRepository roleRepository,
            IWebHostEnvironment hostEnvironment,
            IUserRoleRepository userRoleRepository,
            IMauHopDongRepository mauHopDongRepository,
            IHopDongLaoDongRepository hopDongLaoDongRepository,
            INhatKylamViecRepository nhatKylamViecRepository,
            ILoaiLichBieuRepository loaiLichBieuRepository)
        {
            this.leaverepo = leaverepo;
            this.leaveallocationrepo = leaveallocationrepo;
            this.mapper = mapper;
            this.userManager = userManager;

            this.chucVuRepo = chucVuRepo;
            this.chuyenMonRepo = chuyenMonRepo;
            this.phongBanRepo = phongBanRepo;
            this.roleRepository = roleRepository;
            webHostEnvironment = hostEnvironment;
            this.userRoleRepository = userRoleRepository;
            this.mauHopDongRepository = mauHopDongRepository;
            this.hopDongLaoDongRepository = hopDongLaoDongRepository;
            this.nhatKylamViecRepository = nhatKylamViecRepository;
            this.loaiLichBieuRepository = loaiLichBieuRepository;
  

        }

        // GET: ChamCongController
        public async  Task<ActionResult> Index()
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

        private async Task< ChamCongVMList> FeedSomeDataToIndexAction(int month, int year)
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
                employee.TongTienLuongCoBanDaTichLuyTrongThang = TinhTongLuongCoBanTichLuyTrongThang(nhatKylamViecRepository,employee.Id, year, month);
                employee.TongTienThuongDaTichLuyTrongThang = TinhTongTienThuongDaTichLuyTrongThang(nhatKylamViecRepository,employee.Id, year, month);


                int tongSoPhut = TinhTongSoPhutLamDaTichLuyTrongThang(nhatKylamViecRepository,employee.Id, year, month);
                employee.TongSoGio = new TongSoGioLam();
                employee.TongSoGio.SoGio = tongSoPhut / 60;
                employee.TongSoGio.SoPhut = tongSoPhut % 60;
                employee.TongTienLuong = employee.TongTienLuongCoBanDaTichLuyTrongThang + employee.TongTienThuongDaTichLuyTrongThang;
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
            for (int i=2010; i<2031; i++)
            {
                years.Add(new SelectListItem
                {
                    Text = "Năm " + i,
                    Value = i.ToString()
                });

            }


            var months = new List<SelectListItem>();
            for (int i=1; i<13; i++)
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




        // GET: ChamCongController/Details/5
        public async Task< ActionResult> Details(string EmployeeId, DateTime thoiGianBatDau)
        {
            var model = mapper.Map<CreateEditLichSuChamCongVM>(await nhatKylamViecRepository.FindByMaNhanVienAndThoiGianBatDau(EmployeeId, thoiGianBatDau));

            int soPhut = (int)(model.ThoiGianKetThuc - model.ThoiGianBatDau).TotalMinutes;
             
            model.TongLuongCoBan = (int)((double)model.MucLuongCoBan / (6 * 4 * 8 * 60) * model.HeSoLuongCoBan * soPhut);
            model.TongTienLuong = model.TongLuongCoBan + model.SoTienThuongThem;
            return View(model);
        }

        public async Task<ActionResult> LichSuChamCongList(string employeeId)
        {
            var nhatKyLamViec = await nhatKylamViecRepository.FindByMaNhanVien(employeeId);
            var model = mapper.Map<IEnumerable<LichSuChamCongVM>>(nhatKyLamViec);
            foreach (var nhatky in model)
            {
                int soPhut = (int)(nhatky.ThoiGianKetThuc - nhatky.ThoiGianBatDau).TotalMinutes;
                nhatky.TongLuongCoBan = (int)((double)nhatky.MucLuongCoBan / (6 * 4 * 8 * 60) * nhatky.HeSoLuongCoBan * soPhut);
                nhatky.TongTienLuong = nhatky.TongLuongCoBan + nhatky.SoTienThuongThem;
            }
            var employee = await userManager.FindByIdAsync(employeeId);
            ViewBag.EmployeeName = employee.LastName + " " + employee.MiddleName + " " + employee.FirstName;
            ViewBag.EmployeeId = employeeId;
            ViewBag.ProfilePicture = employee.ProfilePicture;

            return View(model);
        }

        private async Task<CreateEditLichSuChamCongVM> FeedSomeDataToCreateEditVM(CreateEditLichSuChamCongVM model)
        {
            var loaiLichBieus = await loaiLichBieuRepository.FindAll();

            model.LoaiLichBieus = loaiLichBieus.Select(q => new SelectListItem
            {
                Text = q.TenLoaiLichBieu + ", Hệ số lương: " + q.HeSoLuongCoBan,
                Value = q.MaLoai
            });
            model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));

            var hoursOfDate = new List<SelectListItem>();
            for (int i=0; i<24; i++)
            {
                hoursOfDate.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString() + " Giờ"

                });
            }

            var minutesOfHour = new List<SelectListItem>();
            for (int i=0; i<60; i++)
            {
                minutesOfHour.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString() + " Phút"

                }) ;
            }

            model.HoursOfDay = hoursOfDate;
            model.MinutesOfHour = minutesOfHour;
            return model;
        }

        // GET: ChamCongController/Create
        public async Task<ActionResult> Create(string EmployeeId)
        {
            
            var model = new CreateEditLichSuChamCongVM();
            model.MaNhanVien = EmployeeId;
            model = await FeedSomeDataToCreateEditVM(model);
            model.Date = DateTime.Now;
            

            return View(model);
        }

        // POST: ChamCongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEditLichSuChamCongVM model)
        {
            try
            {

                model = await FeedSomeDataToCreateEditVM(model);

                model.ThoiGianBatDau = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day,int.Parse( model.StartHour),int.Parse( model.StartMinute), 0);
                model.ThoiGianKetThuc = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, int.Parse(model.EndHour), int.Parse(model.EndMinute), 0);



                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.ThoiGianBatDau.CompareTo(model.ThoiGianKetThuc)>=0)
                {
                    ModelState.AddModelError("", "Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
                    return View(model);
                }

                var LichSuChamCongList = await nhatKylamViecRepository.FindByMaNhanVien(model.NhanVien.Id);
                foreach (var item in LichSuChamCongList)
                {
                    if (model.ThoiGianBatDau.CompareTo(item.ThoiGianBatDau)>=0 && model.ThoiGianBatDau.CompareTo(item.ThoiGianKetThuc)<0
                        ||
                        model.ThoiGianKetThuc.CompareTo(item.ThoiGianBatDau)>0 && model.ThoiGianKetThuc.CompareTo(item.ThoiGianKetThuc) <= 0)
                    {
                        ModelState.AddModelError("", "Khoảng thời gian được chọn bị trùng với lịch biểu trước đó" +
                            "\n Khoảng thời gian được chọn: " + model.ThoiGianBatDau + " => " + model.ThoiGianKetThuc +
                            "\n Lịch biểu bị trùng: " + item.ThoiGianBatDau + " => " + item.ThoiGianKetThuc);
                    }
                }
                var nhatKyLamViecRecord = mapper.Map<NhatKyLamViec>(model);
                nhatKyLamViecRecord.NgayThemVaoHeThong = DateTime.Now;
                nhatKyLamViecRecord.MucLuongCoBan = model.NhanVien.MucLuongCoBan;
                nhatKyLamViecRecord.HeSoLuongCoBan = (await loaiLichBieuRepository.FindById(model.MaLoaiLichBieu)).HeSoLuongCoBan;
                nhatKyLamViecRecord.MaNhanVienThemVaoHeThong = (await userManager.GetUserAsync(User)).Id;
                nhatKyLamViecRecord.NhanVien = null;


                var isSuccess = await nhatKylamViecRepository.Create(nhatKyLamViecRecord);

                if (!isSuccess)
                {
                    model.NhanVien = mapper.Map<EmployeeVM>( await userManager.FindByIdAsync(model.MaNhanVien));
                    ModelState.AddModelError("", "Lỗi xảy ra khi thêm record vào CSDL");
                    return View(model);
                }

                return RedirectToAction(nameof(LichSuChamCongList), new { employeeId = model.MaNhanVien });
            }
            catch (Exception ex)
            {
                model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                ModelState.AddModelError("", "Lỗi xảy ra khi cập nhật CSDL");
                return View(model);
            }
        }

        // GET: ChamCongController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChamCongController/Edit/5
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

        // GET: ChamCongController/Delete/5
        //[HttpGet("Delete")]
        public async  Task<ActionResult> Delete(string employeeId, DateTime? thoiGianBatDau)
        {

            //var employeeId = id;
            //var thoiGianBatDau = new DateTime();
            
            var nhatKylamViec = await nhatKylamViecRepository.FindByMaNhanVienAndThoiGianBatDau(employeeId, (DateTime) thoiGianBatDau);
            if (nhatKylamViec == null)
            {
                return NotFound();
            }
            var isSuccess = await nhatKylamViecRepository.Delete(nhatKylamViec);
            if (!isSuccess)
            {
                return BadRequest();
            }


            return RedirectToAction(nameof(LichSuChamCongList), new { employeeId = employeeId });
        }

        // POST: ChamCongController/Delete/5
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
