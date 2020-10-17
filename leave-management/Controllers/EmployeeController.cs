using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Controllers
{

    [Authorize(Roles = "Quản trị viên,Trưởng phòng,Trưởng phòng nhân sự")]
    public class EmployeeController : Controller
    {
        private readonly ILeaveTypeRepository _leaverepo;
        private readonly ILeaveAllocationRepository _leaveallocationrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly IChucVuRepository _chucVuRepo;
        private readonly IChuyenMonRepository _chuyenMonRepo;
        private readonly IPhongBanRepository _phongBanRep;
        private readonly IRoleRepository _roleRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserRoleRepository userRoleRepository;

        public EmployeeController(ILeaveTypeRepository leaverepo,
            ILeaveAllocationRepository leaveallocationrepo,
            IMapper mapper,
            UserManager<Employee> userManager,
            IChucVuRepository chucVuRepo,
            IChuyenMonRepository chuyenMonRepo,
            IPhongBanRepository phongBanRepo,
            IRoleRepository roleRepository,
            IWebHostEnvironment hostEnvironment,
            IUserRoleRepository userRoleRepository)
        {
            _leaverepo = leaverepo;
            _leaveallocationrepo = leaveallocationrepo;
            _mapper = mapper;
            _userManager = userManager;

            _chucVuRepo = chucVuRepo;
            _chuyenMonRepo = chuyenMonRepo;
            _phongBanRep = phongBanRepo;
            _roleRepository = roleRepository;
            webHostEnvironment = hostEnvironment;
            this.userRoleRepository = userRoleRepository;
        }

        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            var employees = await _userManager.Users
                .Include(q => q.ChucVu)
                .Include(q => q.ChuyenMon)
                .Include(q => q.PhongBan)
                .ToListAsync();

            var model = _mapper.Map<List<EmployeeVM>>(employees);
            
            foreach (var employee in model)
            {
                var MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
                employee.VaiTroTrenHeThong = await _roleRepository.FindById(MaVaiTroTrenHeThong);
            }
            
            return View(model);
        }

       

        public async Task<ActionResult> SetLeave(int id)
        {
            var leavetype = await _leaverepo.FindById(id);
            var employees = await _userManager.Users.ToListAsync();
            foreach (var emp in employees)
            {
                if (await _leaveallocationrepo.CheckAllocation(id, emp.Id))
                {
                    continue;
                }
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leavetype.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                await _leaveallocationrepo.Create(leaveallocation);
            }
            return RedirectToAction(nameof(Index));
        }

       


        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var employee = _mapper.Map<EmployeeVM>(user);
            employee.NhanVienThemVaoHeThong = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(user.MaNhanVienThemVaoHeThong));
            employee.ChucVu = _mapper.Map<ChucVusVM>(await _chucVuRepo.FindById(user.MaChucVu));
            employee.ChuyenMon = _mapper.Map<ChuyenMonsVM>(await _chuyenMonRepo.FindById(user.MaChuyenMon));
            employee.PhongBan = _mapper.Map<PhongBansVM>(await _phongBanRep.FindById(user.MaPhongBan));

            var maVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
            employee.VaiTroTrenHeThong = await _roleRepository.FindById(maVaiTroTrenHeThong);
            var allocations = _mapper.Map<List<LeaveAllocationVM>>(
                await _leaveallocationrepo.GetLeaveAllocationsByEmployee(id));
            

            var model = new ViewAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations,
                
            };
           
            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public async Task<ActionResult> Create()
        {
            try
            {

                var model = new CreateEmployeeVM();

                model = await AddSomePropertiesToEmployeeVM(model);
                
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeVM model)
        {
            
            try
            {
                model = await AddSomePropertiesToEmployeeVM(model);

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = _mapper.Map<Employee>(model);
                user.MaNhanVienThemVaoHeThong = _userManager.GetUserAsync(HttpContext.User).Result.Id;
                user.UserName = model.Email;
                user.Id = Guid.NewGuid().ToString();
                user.ProfilePicture = UploadedProfilePicture(model);



                if (user.ProfilePicture==null)
                {
                    user.ProfilePicture = "ProfilePicture.webp";
                }

                


                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userRole = new IdentityUserRole<string>
                    {
                        UserId = user.Id,
                        RoleId = model.MaVaiTroTrenHeThong
                    };
                    var isSuccess = await userRoleRepository.Create(userRole);
                    //var roleName = userRoleRepository.findbyroleid
                    //_userManager.AddToRoleAsync(user, model.MaVaiTroTrenHeThong).Wait();

                }
                else 
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }
             

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
        }

        public async Task<CreateEmployeeVM> AddSomePropertiesToEmployeeVM(CreateEmployeeVM model)
        {
            var chucVus = await _chucVuRepo.FindAll();
            var chucVuItems = chucVus.Select(q => new SelectListItem()
            {
                Text = q.TenChucVu,
                Value = q.MaChucVu.ToString()
            });

            var chuyenMons = await _chuyenMonRepo.FindAll();
            var chuyenMonItems = chuyenMons.Select(q => new SelectListItem()
            {
                Text = q.TenChuyenMon,
                Value = q.MaChuyenMon.ToString()
            });

            var phongBans = await _phongBanRep.FindAll();
            var phongBanItems = phongBans.Select(q => new SelectListItem()
            {
                Text = q.TenPhongBan,
                Value = q.MaPhongBan.ToString()
            });

            var vaiTros = await _roleRepository.FindAll();
            var vaiTroItems = new List<SelectListItem>();
            foreach (var vaitro in vaiTros)
            {
                vaiTroItems.Add(new SelectListItem
                {
                    Text = vaitro.Name,
                    Value = vaitro.Id
                });
            }
            //var vaiTroItems = vaiTros.Select(q => new SelectListItem
            //{
            //    Text = q.Name,
            //    Value = q.Id
            //});

            model.CacChucVu = chucVuItems;
            model.CacChuyenMon = chuyenMonItems;
            model.CacPhongBan = phongBanItems;
            model.CacVaiTro = vaiTroItems;
            model.CacLoaiNhanVien = new List<string>()
                    {
                        "Chính thức toàn thời gian",
                        "Chính thức bán thời gian",
                        "Thực tập toàn thời gian",
                        "Thực tập bán thời gian",
                        "Thử việc"
                    };
            return model;
        }

        


        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> EditLeaveAllocation(int id)
        {
            var leaveallocation = await _leaveallocationrepo.FindById(id);
            var model = _mapper.Map<EditLeaveAllocationVM>(leaveallocation);

            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditLeaveAllocation(EditLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var record = await _leaveallocationrepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;
                var isSuccess = await _leaveallocationrepo.Update(record);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while saving");
                    return View(model);
                }
                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });
            }
            catch
            {
                return View();
            }
        }


        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> EditEmployee(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            var model = _mapper.Map<EditEmployeeVM>(employee);

            model = (EditEmployeeVM)(await AddSomePropertiesToEmployeeVM(model));
            model.MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(model.Id);


            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEmployee(EditEmployeeVM model)
        {
            try
            {
                var maVaiTroTrenHeThong_noChanges = model.MaVaiTroTrenHeThong;
                model = (EditEmployeeVM)(await AddSomePropertiesToEmployeeVM(model));
                model.MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(model.Id);


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var employeeRecord = await _userManager.FindByIdAsync(model.Id);

                employeeRecord.Email = model.Email;
                employeeRecord.PhoneNumber = model.PhoneNumber;
                employeeRecord.FirstName = model.FirstName;
                employeeRecord.MiddleName = model.MiddleName;
                employeeRecord.LastName = model.LastName;
                employeeRecord.TaxtId = model.TaxtId;
                employeeRecord.DateOfBirth = model.DateOfBirth;
                employeeRecord.GioiTinh = model.GioiTinh;
                employeeRecord.NoiSinh = model.NoiSinh;
                employeeRecord.DiaChiTamTru = model.DiaChiTamTru;
                employeeRecord.DiaChiLienLac = model.DiaChiLienLac;
                employeeRecord.MaChucVu = model.MaChucVu;
                employeeRecord.MaChuyenMon = model.MaChuyenMon;
                employeeRecord.MaPhongBan = model.MaPhongBan;
                employeeRecord.LoaiNhanVien = model.LoaiNhanVien;
                employeeRecord.SoCMND = model.SoCMND;


                var uriProfilePicture = UploadedProfilePicture(model);
                if (uriProfilePicture !=null)
                {
                    var oldProfilePictureName = employeeRecord.ProfilePicture;
                    employeeRecord.ProfilePicture = uriProfilePicture;
                    DeleteProfilePicture(oldProfilePictureName);
                }

                var changeEmployeeRecordSuccess = (await _userManager.UpdateAsync(employeeRecord)).Succeeded;

                var oldUserRole = await userRoleRepository.FindByUserID(employeeRecord.Id);
                var newUserRole = new IdentityUserRole<string>
                {
                    UserId = employeeRecord.Id,
                    RoleId = maVaiTroTrenHeThong_noChanges
                };
                var changeUserRoleSuccess = await userRoleRepository.Replace(oldUserRole, newUserRole);

                if (!changeEmployeeRecordSuccess || !changeUserRoleSuccess)
                {
                    ModelState.AddModelError("", "Error while saving");
                    return View(model);
                }
                return  RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
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

        private string UploadedProfilePicture(EmployeeVM model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        private void DeleteProfilePicture(string fileName)
        {

            if (fileName !=null && fileName != "ProfilePicture.webp")
            {
                string profilePictureFilePath = Path.Combine(webHostEnvironment.WebRootPath, "images",fileName);
                System.IO.File.Delete(profilePictureFilePath);
            }

        }


    }
}
