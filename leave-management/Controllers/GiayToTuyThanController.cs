using System;
using System.Collections.Generic;
using System.IO;
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
    public class GiayToTuyThanController : Controller
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
        private readonly IGiayToTuyThanRepository GiayToTuyThanRepository;
        private readonly ILoaiGiayToTuyThanRepository loaiGiayToTuyThanRepository;

        public GiayToTuyThanController(ILeaveTypeRepository leaverepo,
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
            IGiayToTuyThanRepository GiayToTuyThanRepository,
            ILoaiGiayToTuyThanRepository loaiGiayToTuyThanRepository)
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
            this.GiayToTuyThanRepository = GiayToTuyThanRepository;
            this.loaiGiayToTuyThanRepository = loaiGiayToTuyThanRepository;
        }
        // GET: GiayToTuyThanController
        public async Task<ActionResult> Index(string id)
        {
            string employeeId = id;
            var GiayToTuyThansOfThisEmployee = (await GiayToTuyThanRepository.FindAll())
                .Where(q => q.MaNhanVien == employeeId);

            var model = new ListGiayToTuyThanVM
            {
                NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(employeeId)),
                GiayToTuyThanVMs = mapper.Map<IEnumerable<GiayToTuyThanVM>>(GiayToTuyThansOfThisEmployee),

            };

            return View(model);
        }

        public async Task<ActionResult> EmployeeList()
        {
            var employees = await userManager.Users.ToListAsync();

            var model = mapper.Map<List<EmployeeVM>>(employees);


            foreach (var employee in model)
            {
                employee.ChucVu = mapper.Map<ChucVusVM>(await chucVuRepo.FindById(employee.MaChucVu));
                employee.ChuyenMon = mapper.Map<ChuyenMonsVM>(await chuyenMonRepo.FindById(employee.MaChuyenMon));
                employee.PhongBan = mapper.Map<PhongBansVM>(await phongBanRep.FindById(employee.MaPhongBan));
                var MaVaiTroTrenHeThong = await userRoleRepository.FindRoleIdByUserID(employee.Id);
                employee.VaiTroTrenHeThong = await roleRepository.FindById(MaVaiTroTrenHeThong);
            }

            return View(model);

        }

        // GET: GiayToTuyThanController/Details/5
        public async Task<ActionResult> Details(string employeeId, string maLoaiGiayTo)
        {
            var giayTo = (await GiayToTuyThanRepository.FindAll())
                .Where(q => q.MaNhanVien == employeeId && q.MaLoaiGiayTo == maLoaiGiayTo)
                .FirstOrDefault();
                
            var model = mapper.Map<GiayToTuyThanVM>(giayTo);

            return View(model);
        }

        // GET: GiayToTuyThanController/Create
        public async Task<ActionResult> Create(string employeeId)
        {


            var model = new CreateEditGiayToTuyThanVM();
            model = await FeedSomeDataToCreateEditVM(model);

            model.MaNhanVien = employeeId;
            model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(employeeId));

            return View(model);
        }

        // POST: GiayToTuyThanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEditGiayToTuyThanVM model)
        { 
            try
            {
                model = await FeedSomeDataToCreateEditVM(model);

                if (!ModelState.IsValid)
                {
                    model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                    return View(model);
                }

                var GiayToTuyThan = mapper.Map<GiayToTuyThan>(model);
                GiayToTuyThan.NgayLuuVaoHeThong = DateTime.Now;
                GiayToTuyThan.MaNhanVienGui =(await userManager.GetUserAsync(HttpContext.User)).Id;
                GiayToTuyThan.ViTriLuuBanScan = UploadGiayToTuyThan(model);

                if (GiayToTuyThan.ViTriLuuBanScan == null)
                {
                    ModelState.AddModelError("", "File Scan giấy tờ tùy thân cần được chọn");
                    model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                    return View(model);
                }

                GiayToTuyThan.NhanVien = null;

                var isSuccess = await GiayToTuyThanRepository.Create(GiayToTuyThan);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while creating record on database");
                    model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                    return View(model);
                }



                return RedirectToAction(nameof(Index), new { id = model.MaNhanVien });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                return View(model);
            }
        }

        private async Task<CreateEditGiayToTuyThanVM> FeedSomeDataToCreateEditVM(CreateEditGiayToTuyThanVM model)
        {


            var mauHopDongs = await mauHopDongRepository.FindAll();

            model.MauGiayToTuyThans = loaiGiayToTuyThanRepository.FindAll().Result.Select(q => new SelectListItem
            {
                Text = q.TenLoaiGiayTo,
                Value = q.MaLoaiGiayTo
            });

            return model;

        }

        // GET: GiayToTuyThanController/Edit/5
        public async Task<ActionResult> Edit(string employeeId, string maLoaiGiayTo)
        {
            if (!(await GiayToTuyThanRepository.isExist(employeeId,maLoaiGiayTo)))
            {
                return NotFound();
            }

            var giayTo = (await GiayToTuyThanRepository.FindAll())
                .Where(q => q.MaNhanVien == employeeId && q.MaLoaiGiayTo == maLoaiGiayTo)
                .FirstOrDefault() ;
            var model = mapper.Map<CreateEditGiayToTuyThanVM>(giayTo);
            model = await FeedSomeDataToCreateEditVM(model);
            model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));

            return View(model);
        }

        // POST: GiayToTuyThanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateEditGiayToTuyThanVM model)
        {
            try
            {
                model = await FeedSomeDataToCreateEditVM(model);
                model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var giayTo = mapper.Map<GiayToTuyThan>(model);

                var uriGiayToFile = UploadGiayToTuyThan(model);
                if (uriGiayToFile != null)
                {
                    var oldGiayToName = giayTo.ViTriLuuBanScan;
                    giayTo.ViTriLuuBanScan = uriGiayToFile;
                    DeleteFileHopDong(oldGiayToName);
                }
                giayTo.MaNhanVienChinhSuaLanCuoi = userManager.GetUserAsync(HttpContext.User).Result.Id;
                giayTo.ThoiGianChinhSuaLanCuoi = DateTime.Now;
                giayTo.NhanVien = null;

                var isSuccess = await GiayToTuyThanRepository.Update(giayTo);
                if (!isSuccess)
                {
                    model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index), new { id = model.MaNhanVien });
            }
            catch (Exception ex)
            {
                model.NhanVien = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.MaNhanVien));
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }


        // GET: GiayToTuyThanController/Delete/5
        public async Task<ActionResult> Delete(string employeeId, string maLoaiGiayTo)
        {
            var giayTo = (await GiayToTuyThanRepository.FindAll())
                .Where(q => q.MaNhanVien == employeeId && q.MaLoaiGiayTo == maLoaiGiayTo)
                .FirstOrDefault();
            if (giayTo == null)
            {
                return NotFound();
            }
            var isSuccess = await GiayToTuyThanRepository.Delete(giayTo);

            if (!isSuccess)
            {
                return BadRequest();
            }
            DeleteFileHopDong(giayTo.ViTriLuuBanScan);


            return RedirectToAction(nameof(Index), new { id = employeeId });
        }

        // POST: GiayToTuyThanController/Delete/5
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
        public async Task<IActionResult> DownloadGiayToTuyThan(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           @"wwwroot\giayToTuyThans", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string UploadGiayToTuyThan(CreateEditGiayToTuyThanVM model)
        {
            string uniqueFileName = null;

            if (model.FileGiayToTuyThanScan != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "GiayToTuyThans");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileGiayToTuyThanScan.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FileGiayToTuyThanScan.CopyTo(fileStream);
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
                string GiayToTuyThanFilePath = Path.Combine(webHostEnvironment.WebRootPath, "GiayToTuyThans", fileName);
                System.IO.File.Delete(GiayToTuyThanFilePath);
            }

        }
    }
}
