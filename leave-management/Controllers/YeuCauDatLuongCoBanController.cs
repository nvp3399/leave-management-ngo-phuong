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
    [Authorize(Roles ="Quản trị viên,Nhân viên phòng nhân sự,Trưởng phòng nhân sự")]
    public class YeuCauDatLuongCoBanController : Controller
    {
        private readonly IYeuCauDatLuongCoBanRepository _YeuCauDatLuongCoBanRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly UserManager<Employee> _userManager;

        public YeuCauDatLuongCoBanController(
            IYeuCauDatLuongCoBanRepository YeuCauDatLuongCoBanRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            ILeaveTypeRepository leaveTypeRepo,
            IMapper mapper,
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            UserManager<Employee> userManager)
        {
            _leaveTypeRepo = leaveTypeRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _YeuCauDatLuongCoBanRepo = YeuCauDatLuongCoBanRepo;
            _mapper = mapper;
            this.userRoleRepository = userRoleRepository;
            this.roleRepository = roleRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Quản trị viên,Trưởng phòng nhân sự")]
        // GET: YeuCauDatLuongCoBanController
        public async Task<ActionResult> Index()
        {
            var YeuCauDatLuongCoBans = await _YeuCauDatLuongCoBanRepo.FindAll();
            var YeuCauDatLuongCoBansModel = _mapper.Map<List<YeuCauDatLuongCoBanVM>>(YeuCauDatLuongCoBans);
            var model = new AdminYeuCauDatLuongCoBanViewVM
            {
                TotalRequests = YeuCauDatLuongCoBansModel.Count,
                ApprovedRequets = YeuCauDatLuongCoBansModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaDuocChapThuan]),
                PendingRequests = YeuCauDatLuongCoBansModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DangCho]),
                RejectedRequests = YeuCauDatLuongCoBansModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaBiTuChoi]),
                CancelledRequests = YeuCauDatLuongCoBansModel
                                        .Count(q => q.TinhTrangPheDuyet == YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaBiHuy]),
                YeuCauDatLuongCoBans = YeuCauDatLuongCoBansModel

            };
            return View(model);
        }

        // GET: YeuCauDatLuongCoBanController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var YeuCauDatLuongCoBan = await _YeuCauDatLuongCoBanRepo.FindById(id);
            var model = _mapper.Map<YeuCauDatLuongCoBanVM>(YeuCauDatLuongCoBan);
            return View(model);
        }

        public async Task<ActionResult> ApproveRequest(string id)
        {
            try
            {

                
                var yeuCauDatLuongCoBan = await _YeuCauDatLuongCoBanRepo.FindById(id);


                yeuCauDatLuongCoBan.MaNhanVienPheDuyet = (await _userManager.GetUserAsync(User)).Id;
                yeuCauDatLuongCoBan.TinhTrangPheDuyet = YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaDuocChapThuan];
                yeuCauDatLuongCoBan.ThoiGianPheDuyet = DateTime.Now;

                var employeeDuocDatLuong= (await _userManager.FindByIdAsync(yeuCauDatLuongCoBan.MaNhanVienDuocDatLuong));
                employeeDuocDatLuong.MucLuongCoBan = yeuCauDatLuongCoBan.MucLuongCoBan;

                await _YeuCauDatLuongCoBanRepo.Update(yeuCauDatLuongCoBan);
                await _userManager.UpdateAsync(employeeDuocDatLuong);
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<ActionResult> RejectRequest(string id)
        {
            try
            {
                var yeuCauDatLuongCoBan = await _YeuCauDatLuongCoBanRepo.FindById(id);


                yeuCauDatLuongCoBan.MaNhanVienPheDuyet = (await _userManager.GetUserAsync(User)).Id;
                yeuCauDatLuongCoBan.TinhTrangPheDuyet = YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaBiTuChoi];
                yeuCauDatLuongCoBan.ThoiGianPheDuyet = DateTime.Now;



                await _YeuCauDatLuongCoBanRepo.Update(yeuCauDatLuongCoBan);


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


            var YeuCauDatLuongCoBans = (await _YeuCauDatLuongCoBanRepo.FindAll())
                                    .Where(q => q.MaNhanVienGuiYeuCau == employee.Id);


            var YeuCauDatLuongCoBansVM = _mapper.Map<List<YeuCauDatLuongCoBanVM>>(YeuCauDatLuongCoBans);




            var model = new EmployeeYeuCauDatLuongCoBanViewVM
            {
                YeuCauDatLuongCoBans = YeuCauDatLuongCoBansVM,
                NhanVienYeuCau = _mapper.Map<EmployeeVM>(employee)
            };

            return View(model);
        }

        // GET: YeuCauDatLuongCoBanController/Create
        public async Task<ActionResult> Create(string employeeChuTheId)
        {


            var model = new YeuCauDatLuongCoBanVM();
            model.MaNhanVienDuocDatLuong = employeeChuTheId;
            
            return View(model);
        }

        // POST: YeuCauDatLuongCoBanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(YeuCauDatLuongCoBanVM model)
        {

            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                if (model.MucLuongCoBan  <= 0)
                {
                    ModelState.AddModelError("", "Mức lương phải lớn hơn 0");
                    return View(model);
                }


                var employee = await _userManager.GetUserAsync(User);



                var yeuCauDatLuongCoBan = _mapper.Map<YeuCauDatLuongCoBan>(model);
                yeuCauDatLuongCoBan.MaNhanVienGuiYeuCau = (await _userManager.GetUserAsync(User)).Id;
                yeuCauDatLuongCoBan.ThoiGianGuiYeuCau = DateTime.Now;
                yeuCauDatLuongCoBan.MaYeuCau = Guid.NewGuid().ToString();
                yeuCauDatLuongCoBan.TinhTrangPheDuyet = YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DangCho];

                var isSuccess = await _YeuCauDatLuongCoBanRepo.Create(yeuCauDatLuongCoBan);

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

        // GET: YeuCauDatLuongCoBanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: YeuCauDatLuongCoBanController/Edit/5
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

        // GET: YeuCauDatLuongCoBanController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var request = await _YeuCauDatLuongCoBanRepo.FindById(id);
            if (request == null)
            {
                return NotFound();
            }
            var isSuccess = await _YeuCauDatLuongCoBanRepo.Delete(request);


            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: YeuCauDatLuongCoBanController/Delete/5
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
                var yeuCauDatLuongCoBan = await _YeuCauDatLuongCoBanRepo.FindById(id);
                yeuCauDatLuongCoBan.TinhTrangPheDuyet = YeuCauDatLuongCoBanStatusString[YeuCauDatLuongCoBanStatus.DaBiHuy];
                await _YeuCauDatLuongCoBanRepo.Update(yeuCauDatLuongCoBan);
                return RedirectToAction(nameof(MyRequest));

            }
            catch
            {
                ModelState.AddModelError("", "Cannot cancel this Request because of unknown reason.");
                return RedirectToAction(nameof(MyRequest));
            }
        }

        public async Task<ActionResult> ChooseEmployee()
        {
            var employees = await _userManager.Users
                .Include( q => q.ChucVu)
                .Include( q => q.ChuyenMon)
                .Include( q => q.PhongBan)
                .ToListAsync();


            var model = _mapper.Map<List<EmployeeVM>>(employees);

            foreach (var employee in model)
            {
                var MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
                employee.VaiTroTrenHeThong = await roleRepository.FindById(MaVaiTroTrenHeThong);

            }

            return View(model);
        }

    }
}
