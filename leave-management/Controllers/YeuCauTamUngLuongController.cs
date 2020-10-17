using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static leave_management.GeneralData.Data;

namespace leave_management.Controllers
{
    [Authorize]
    public class YeuCauTamUngLuongController : Controller
    {
        private readonly IYeuCauTamUngLuongRepository _YeuCauTamUngLuongRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IPhieuChi_TamUngLuongRepository phieuChi_TamUngLuongRepository;
        private readonly UserManager<Employee> _userManager;

        public YeuCauTamUngLuongController(
            IYeuCauTamUngLuongRepository YeuCauTamUngLuongRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            ILeaveTypeRepository leaveTypeRepo,
            IMapper mapper,
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            IPhieuChi_TamUngLuongRepository phieuChi_TamUngLuongRepository,
            UserManager<Employee> userManager)
        {
            _leaveTypeRepo = leaveTypeRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _YeuCauTamUngLuongRepo = YeuCauTamUngLuongRepo;
            _mapper = mapper;
            this.userRoleRepository = userRoleRepository;
            this.roleRepository = roleRepository;
            this.phieuChi_TamUngLuongRepository = phieuChi_TamUngLuongRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Quản trị viên,Nhân viên phòng nhân sự,Trưởng phòng nhân sự")]
        // GET: YeuCauTamUngLuongController
        public async Task<ActionResult> Index()
        {
            var YeuCauTamUngLuongs = await _YeuCauTamUngLuongRepo.FindAll();
            var YeuCauTamUngLuongsModel = _mapper.Map<List<YeuCauTamUngLuongVM>>(YeuCauTamUngLuongs);
            var model = new AdminYeuCauTamUngLuongViewVM
            {
                TotalRequests = YeuCauTamUngLuongsModel.Count,
                ApprovedRequets = YeuCauTamUngLuongsModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaDuocChapThuan]),
                PendingRequests = YeuCauTamUngLuongsModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DangCho]),
                RejectedRequests = YeuCauTamUngLuongsModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaBiTuChoi]),
                CancelledRequests = YeuCauTamUngLuongsModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaBiHuy]),
                YeuCauTamUngLuongs = YeuCauTamUngLuongsModel

            };
            return View(model);
        }

        // GET: YeuCauTamUngLuongController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var YeuCauTamUngLuong = await _YeuCauTamUngLuongRepo.FindById(id);
            var model = _mapper.Map<YeuCauTamUngLuongVM>(YeuCauTamUngLuong);
            return View(model);
        }

        public async Task<ActionResult> ApproveRequest(string id)
        {
            try
            {

                var yeuCauTamUngLuong = await _YeuCauTamUngLuongRepo.FindById(id);


                yeuCauTamUngLuong.MaNhanVienPheDuyet = (await _userManager.GetUserAsync(User)).Id;
                yeuCauTamUngLuong.TinhTrangPheDuyet = YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaDuocChapThuan];
                yeuCauTamUngLuong.NgayPheDuyet = DateTime.Now;

                var phieuChi = new PhieuChi_TamUngLuong
                {
                    MaPhieuChi = Guid.NewGuid().ToString(),
                    ThoiGianXuatPhieuChi = DateTime.Now,
                    MaYeuCauTamUngLuong = yeuCauTamUngLuong.MaYeuCau
                };

                
                var updateYeuCauTamUngLuongSuccess = await _YeuCauTamUngLuongRepo.Update(yeuCauTamUngLuong);
                var updatePhieuChiSuccess = await phieuChi_TamUngLuongRepository.Create(phieuChi);

                if (!updateYeuCauTamUngLuongSuccess || !updatePhieuChiSuccess )
                {
                    throw new Exception("error while updating and creating something on database");
                }


                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<ActionResult> RejectRequest(string id)
        {
            try
            {
                var YeuCauTamUngLuong = await _YeuCauTamUngLuongRepo.FindById(id);

                YeuCauTamUngLuong.MaNhanVienPheDuyet = (await _userManager.GetUserAsync(User)).Id;
                YeuCauTamUngLuong.TinhTrangPheDuyet = YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaBiTuChoi];
                YeuCauTamUngLuong.NgayPheDuyet = DateTime.Now;

                await _YeuCauTamUngLuongRepo.Update(YeuCauTamUngLuong);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<ActionResult> MyRequest()
        {

            var employee = await _userManager.GetUserAsync(User);


            var YeuCauTamUngLuongs = (await _YeuCauTamUngLuongRepo.FindAll())
                                    .Where(q => q.MaNhanVienGuiYeuCau == employee.Id);


            var YeuCauTamUngLuongsVM = _mapper.Map<List<YeuCauTamUngLuongVM>>(YeuCauTamUngLuongs);




            var model = new EmployeeYeuCauTamUngLuongViewVM
            {
                YeuCauTamUngLuongs = YeuCauTamUngLuongsVM,
                NhanVienYeuCau = _mapper.Map<EmployeeVM>(employee)
            };

            return View(model);
        }

        // GET: YeuCauTamUngLuongController/Create
        public async Task<ActionResult> Create(string employeeId)
        {


            var model = new YeuCauTamUngLuongVM();
            model.MaNhanVienGuiYeuCau = employeeId;

            return View(model);
        }

        // POST: YeuCauTamUngLuongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(YeuCauTamUngLuongVM model)
        {

            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                if (model.SoTienTamUng <= 0)
                {
                    ModelState.AddModelError("", "Số tiền tạm ứng phải lớn hơn 0");
                    return View(model);
                }


                var employee = await _userManager.GetUserAsync(User);


                var yeuCauTamUngLuong = _mapper.Map<YeuCauTamUngLuong>(model);
                yeuCauTamUngLuong.MaNhanVienGuiYeuCau = (await _userManager.GetUserAsync(User)).Id;
                yeuCauTamUngLuong.NgayGuiYeuCau = DateTime.Now;
                yeuCauTamUngLuong.MaYeuCau = Guid.NewGuid().ToString();
                yeuCauTamUngLuong.TinhTrangPheDuyet = YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DangCho];

                var isSuccess = await _YeuCauTamUngLuongRepo.Create(yeuCauTamUngLuong);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record");
                    return View(model);
                }
                return RedirectToAction(nameof(MyRequest));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: YeuCauTamUngLuongController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: YeuCauTamUngLuongController/Edit/5
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

        // GET: YeuCauTamUngLuongController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var request = await _YeuCauTamUngLuongRepo.FindById(id);
            if (request == null)
            {
                return NotFound();
            }
            var isSuccess = await _YeuCauTamUngLuongRepo.Delete(request);


            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: YeuCauTamUngLuongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(MyRequest));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Cancelled(string id)
        {
            try
            {
                var YeuCauTamUngLuong = await _YeuCauTamUngLuongRepo.FindById(id);
                YeuCauTamUngLuong.TinhTrangPheDuyet = YeuCauTamUngLuongStatusString[YeuCauTamUngLuongStatus.DaBiHuy];
                await _YeuCauTamUngLuongRepo.Update(YeuCauTamUngLuong);
                return RedirectToAction(nameof(MyRequest));

            }
            catch
            {
                ModelState.AddModelError("", "Cannot cancel this Request because of unknown reason.");
                return RedirectToAction(nameof(MyRequest));
            }
        }

        //public async Task<ActionResult> ChooseEmployee()
        //{
        //    var employees = await _userManager.Users
        //        .Include(q => q.ChucVu)
        //        .Include(q => q.ChuyenMon)
        //        .Include(q => q.PhongBan)
        //        .ToListAsync();


        //    var model = _mapper.Map<List<EmployeeVM>>(employees);

        //    foreach (var employee in model)
        //    {
        //        var MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
        //        employee.VaiTroTrenHeThong = await roleRepository.FindById(MaVaiTroTrenHeThong);

        //    }

        //    return View(model);
        //}

    }
}
