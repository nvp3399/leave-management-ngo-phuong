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

namespace leave_management.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestController(
            ILeaveRequestRepository leaveRequestRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            ILeaveTypeRepository leaveTypeRepo,
            IMapper mapper,
            UserManager<Employee> userManager)
        {
            _leaveTypeRepo = leaveTypeRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _leaveRequestRepo = leaveRequestRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles ="Quản trị viên,Trưởng phòng,Trưởng phòng nhân sự")]
        // GET: LeaveRequestController
        public async Task<ActionResult> Index()
        {
            var leaveRequests = await _leaveRequestRepo.FindAll();
            var leaveRequestsModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequestsModel.Count,
                ApprovedRequets = leaveRequestsModel
                                        .Count(q => q.Approved == true),
                PendingRequests = leaveRequestsModel
                                        .Count(q => q.Approved == null),
                RejectedRequests = leaveRequestsModel
                                        .Count(q => q.Approved == false),
                CancelledRequests = leaveRequestsModel
                                        .Count(q => q.Cancelled == true),
                LeaveRequests = leaveRequestsModel

            };
            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveRequest = await _leaveRequestRepo.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            return View(model);
        }

        public async Task<ActionResult> ApproveRequest(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                var employeeId = leaveRequest.RequestingEmployeeId;
                var leaveTypeId = leaveRequest.LeaveTypeId;
                var allocation = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeAndType(employeeId,leaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                
                leaveRequest.Approved = true;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                await _leaveRequestRepo.Update(leaveRequest);
                await _leaveAllocationRepo.Update(allocation);

                return RedirectToAction(nameof(Index));


            }
            catch 
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            try
            {
                var user =await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                leaveRequest.Approved = false;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                await _leaveRequestRepo.Update(leaveRequest);
                return RedirectToAction(nameof(Index));


            }
            catch 
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<ActionResult> MyLeave()
        {

            var employee = await _userManager.GetUserAsync(User);


            var leaveRequests =  (await _leaveRequestRepo.FindAll())
                                    .Where(q => q.RequestingEmployeeId == employee.Id);
            var leaveAllocations = (await _leaveAllocationRepo.FindAll())
                                    .Where(q => q.EmployeeId == employee.Id);

            var leaveAllocationsIds = (await _leaveAllocationRepo.FindAll())
                .Where(q => q.EmployeeId == employee.Id.ToString())
                .Select(q => q.LeaveTypeId);
            var leaveTypeInfo = (await _leaveTypeRepo.FindAll())
                                    .Where(q => leaveAllocationsIds.Contains(q.Id));

            


            var leaveRequestsVM = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);
            var leaveAllocationsVM = _mapper.Map<List<LeaveAllocationVM>>(leaveAllocations);
            var leaveTypeInfoVM = _mapper.Map<List<LeaveTypeVM>>(leaveTypeInfo);

            

            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveRequests = leaveRequestsVM,
                LeaveAllocations = leaveAllocationsVM,
                LeaveTypesInfo = leaveTypeInfoVM
            };
           
            return View(model);
        }

        // GET: LeaveRequestController/Create
        public async Task<ActionResult> Create()
        {
            var employee = await _userManager.GetUserAsync(User);

            var leaveAllocationsIds = (await _leaveAllocationRepo.FindAll())
                .Where(q => q.EmployeeId == employee.Id.ToString())
                .Select( q => q.LeaveTypeId);

            var leaveTypes = (await _leaveTypeRepo.FindAll())
                .Where(q => leaveAllocationsIds.Contains(q.Id));

            var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new CreateLeaveRequestVM
            {
                LeaveTypes = leaveTypeItems
          
            };
            return View(model);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVM model)
        {

            try
            {
                var StartDate = Convert.ToDateTime(model.StartDate);
                var EndDate = Convert.ToDateTime(model.EndDate);

                var leaveTypes = _leaveTypeRepo.FindAll();
                var leaveTypeItems = (await leaveTypes).Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                model.LeaveTypes = leaveTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (DateTime.Compare(StartDate, EndDate) > 0)
                {
                    ModelState.AddModelError("", "Ngày kết thúc phải sau ngày bắt đầu.");
                    return View(model);
                }

                if (DateTime.Compare(StartDate, DateTime.Now.Date) < 0)
                {
                    ModelState.AddModelError("", "Ngày bắt đầu và ngày kết thúc phải ở tương lai." + DateTime.Now.Date.ToString());
                    return View(model);
                }


                var employee =  await _userManager.GetUserAsync(User);
                var allocation = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeAndType(employee.Id, model.LeaveTypeId);
                int daysRequested = (int)(EndDate - StartDate).TotalDays;

                if(daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "Số ngày bạn yêu cầu vượt quá số ngày cho phép");
                    return View(model);
                }

                var previousApprovedLeaveRequests = (await _leaveRequestRepo.FindAll())
                    .Where(q => q.RequestingEmployeeId == employee.Id && q.Approved == true);
                foreach (var request in previousApprovedLeaveRequests)
                {
                    if (DateTime.Compare(StartDate, request.StartDate) >0 && DateTime.Compare(StartDate, request.EndDate) < 0 ||
                        DateTime.Compare(EndDate, request.StartDate) > 0 && DateTime.Compare(EndDate, request.EndDate) < 0 ||
                        DateTime.Compare(StartDate, request.StartDate) <= 0 && DateTime.Compare(EndDate, request.EndDate) >= 0
                        )
                    {
                        ModelState.AddModelError("", "Khoảng thời gian nghỉ phép mà bạn yêu cầu trùng với khoảng thời gian nghỉ phép đã được chấp thuận trước đó.");
                        return View(model);
                    }
                }



                var leaveRequestModel = new LeaveRequestVM
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    ApprovedById = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = model.LeaveTypeId
                };

                var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestModel);
                var isSuccess = await _leaveRequestRepo.Create(leaveRequest);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record");
                    return View(model);
                }
                return RedirectToAction(nameof(MyLeave));

            }
            catch 
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
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

        // GET: LeaveRequestController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var leavetype = await _leaveRequestRepo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var isSuccess = await _leaveRequestRepo.Delete(leavetype);


            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(MyLeave));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Cancelled(int id)
        {
            try
            {
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                leaveRequest.Cancelled = true;
                await _leaveRequestRepo.Update(leaveRequest);
                return RedirectToAction(nameof(MyLeave));

            }
            catch
            {
                ModelState.AddModelError("", "Cannot cancel this Request because of unknown reason.");
                return RedirectToAction(nameof(MyLeave));
            }
        }

    }
}
