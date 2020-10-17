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

namespace leave_management.Controllers
{
    [Authorize(Roles ="Nhân viên phòng nhân sự,Trưởng phòng nhân sự,Quản trị viên")]
    public class HopDongLaoDongController : Controller
    {
        private readonly ILeaveTypeRepository leaverepo;
        private readonly ILeaveAllocationRepository leaveallocationrepo;
        private readonly IMapper mapper;
        private readonly UserManager<Employee> userManager;
        private readonly IChucVuRepository chucVuRepo;
        private readonly IChuyenMonRepository chuyenMonRepo;
        private readonly IPhongBanRepository phongBanRep;
        private readonly IRoleRepository roleRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IMauHopDongRepository mauHopDongRepository;
        private readonly IHopDongLaoDongRepository hopDongLaoDongRepository;

        public HopDongLaoDongController(ILeaveTypeRepository leaverepo,
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
            IHopDongLaoDongRepository hopDongLaoDongRepository)
        {
            this.leaverepo = leaverepo;
            this.leaveallocationrepo = leaveallocationrepo;
            this.mapper = mapper;
            this.userManager = userManager;

            this.chucVuRepo = chucVuRepo;
            this.chuyenMonRepo = chuyenMonRepo;
            phongBanRep = phongBanRepo;
            this.roleRepository = roleRepository;
            webHostEnvironment = hostEnvironment;
            this.userRoleRepository = userRoleRepository;
            this.mauHopDongRepository = mauHopDongRepository;
            this.hopDongLaoDongRepository = hopDongLaoDongRepository;
        }
        // GET: HopDongLaoDongController
        public async Task<ActionResult> Index(string id)
        {
            string employeeId = id;
            var hopDongLaoDongsOfThisEmployee = await hopDongLaoDongRepository.FindByEmployeeChuTheId(employeeId);
            var model = new ListHopDongLaoDongVM
            {
                EmployeeChuTheHopDong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(employeeId)),
                HopDongLaoDongVMs = mapper.Map<IEnumerable<HopDongLaoDongVM>>(hopDongLaoDongsOfThisEmployee),

            };
                                                                    
            return View(model);
        }

        // GET: HopDongLaoDongController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var hopDong = await hopDongLaoDongRepository.FindById(id);
            var model = mapper.Map<HopDongLaoDongVM>(hopDong);

            return View(model);
        }

        // GET: HopDongLaoDongController/Create
        public async Task<ActionResult> Create(string employeeId)
        {


            var model = new CreateEditHopDongLaoDongVM();
            model = await FeedSomeDataToCreateEditVM(model);
            model.NgayKyKet = DateTime.Now;
            model.NgayBatDau = DateTime.Now;
            model.NgayKetThuc = DateTime.Now;
            model.MaNhanVienChuTheHopDong = employeeId;
            model.NhanVienChuTheHopDong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(employeeId));

            return View(model);
        }

        // POST: HopDongLaoDongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(CreateEditHopDongLaoDongVM model)
        {
            try
            {
                model = await FeedSomeDataToCreateEditVM(model);
                model.NgayKyKet = DateTime.Now;
                model.NgayBatDau = DateTime.Now;
                model.NgayKetThuc = DateTime.Now;
                model.NhanVienChuTheHopDong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVienChuTheHopDong));
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var hopDongLaoDong = mapper.Map<HopDongLaoDong>(model);
                hopDongLaoDong.NgayGuiBanScan = DateTime.Now;
                hopDongLaoDong.MaNhanVienGuiBanScan =(await userManager.GetUserAsync(User)).Id;
                hopDongLaoDong.MaHopDong = Guid.NewGuid().ToString();
                hopDongLaoDong.NhanVienChuTheHopDong = null;
                hopDongLaoDong.ViTriLuuBanScan = UploadHopDongLaoDong(model);

                if (hopDongLaoDong.ViTriLuuBanScan == null)
                {
                    ModelState.AddModelError("", "File Scan Hợp đồng lao động cần được chọn");
                    return View(model);
                }

                var isSuccess = await hopDongLaoDongRepository.Create(hopDongLaoDong);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while creating record on database");
                    return View(model);
                }



                return RedirectToAction(nameof(Index), new { id = model.MaNhanVienChuTheHopDong });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        private async Task<CreateEditHopDongLaoDongVM> FeedSomeDataToCreateEditVM(CreateEditHopDongLaoDongVM model)
        {
            
       
            var mauHopDongs = await mauHopDongRepository.FindAll();

            model.MauHopDongs = mauHopDongs.Select(q => new SelectListItem
            {
                Text = q.TenMauHopDong,
                Value = q.MaMauHopDong
            });

            return model;

        }

        // GET: HopDongLaoDongController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (!(await hopDongLaoDongRepository.isExist(id)))
            {
                return NotFound();
            }

            var hopDong = await hopDongLaoDongRepository.FindById(id);
            var model = mapper.Map<CreateEditHopDongLaoDongVM>(hopDong);
            model = await FeedSomeDataToCreateEditVM(model);
            model.NhanVienChuTheHopDong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVienChuTheHopDong));

            return View(model);
        }

        // POST: HopDongLaoDongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateEditHopDongLaoDongVM model)
        {
            try
            {
                model = await FeedSomeDataToCreateEditVM(model);
                model.NhanVienChuTheHopDong = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVienChuTheHopDong));

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var hopDong = mapper.Map<HopDongLaoDong>(model);

                var uriMauHopDongFile = UploadHopDongLaoDong(model);
                if (uriMauHopDongFile != null)
                {
                    var oldMauHopDongName = hopDong.ViTriLuuBanScan;
                    hopDong.ViTriLuuBanScan = uriMauHopDongFile;
                    DeleteFileHopDong(oldMauHopDongName);
                }
                hopDong.MaNhanVienChinhSuaLanCuoi = userManager.GetUserAsync(HttpContext.User).Result.Id;
                hopDong.ThoiGianChinhSuaLanCuoi = DateTime.Now;
                hopDong.NhanVienChuTheHopDong = null;

                var isSuccess = await hopDongLaoDongRepository.Update(hopDong);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index), new { id = model.MaNhanVienChuTheHopDong });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }
        

        // GET: HopDongLaoDongController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var hopDong = await hopDongLaoDongRepository.FindById(id);
            var employeeId = hopDong.MaNhanVienChuTheHopDong;
            if (hopDong == null)
            {
                return NotFound();
            }
            var isSuccess = await hopDongLaoDongRepository.Delete(hopDong);

            if (!isSuccess)
            {
                return BadRequest();
            }
            DeleteFileHopDong(hopDong.ViTriLuuBanScan);


            return RedirectToAction(nameof(Index),new {id = employeeId });
        }

        // POST: HopDongLaoDongController/Delete/5
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
        public async Task<IActionResult> DownloadHopDongLaoDong(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           @"wwwroot\hopDongLaoDongs", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string UploadHopDongLaoDong(CreateEditHopDongLaoDongVM model)
        {
            string uniqueFileName = null;

            if (model.FileHopDongScan != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "hopDongLaoDongs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileHopDongScan.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FileHopDongScan.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        private void DeleteFileHopDong(string fileName)
        {


            if (fileName != null)
            {
                string hopDongLaoDongFilePath = Path.Combine(webHostEnvironment.WebRootPath, "hopDongLaoDongs", fileName);
                System.IO.File.Delete(hopDongLaoDongFilePath);
            }

        }
    }
}
