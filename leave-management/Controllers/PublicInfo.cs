using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace leave_management.Controllers
{
    [Authorize]
    public class PublicInfo : Controller
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
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IPhongBanRepository phongBanRepository;

        public PublicInfo(ILeaveTypeRepository leaverepo,
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
            ILoaiLichBieuRepository loaiLichBieuRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IPhongBanRepository phongBanRepository)
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
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveRequestRepository = leaveRequestRepository;
            this.leaveTypeRepository = leaveTypeRepository;
            this.phongBanRepository = phongBanRepository;
        }

        // GET: PublicInfo
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Employee(string id)
        {
            var employee = userManager.FindByIdAsync(id).Result;

            var model = mapper.Map<EmployeeVM>(employee);

            model.ChucVu = mapper.Map<ChucVusVM>( chucVuRepo.FindById(model.MaChucVu).Result);
            model.ChuyenMon = mapper.Map<ChuyenMonsVM>(chuyenMonRepo.FindById(model.MaChuyenMon).Result);
            model.PhongBan = mapper.Map<PhongBansVM>(phongBanRepo.FindById(model.MaPhongBan).Result);

            ViewBag.VaiTroTrenHeThong = userManager.GetRolesAsync(employee).Result.FirstOrDefault();

            return View(model);
        }


        // GET: PublicInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicInfo/Create
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

        // GET: PublicInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicInfo/Edit/5
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

        // GET: PublicInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicInfo/Delete/5
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
