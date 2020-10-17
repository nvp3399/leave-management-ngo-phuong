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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Controllers
{
    [Authorize(Roles ="Quản trị viên,Trưởng phòng nhân sự,Nhân viên phòng nhân sự")]
    public class MauHopDongLaoDongController : Controller
    {
        private readonly IMauHopDongRepository _mauHopDongRepository;
        private readonly ILoaiHopDongRepository loaiHopDongRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<Employee> userManager;
        private readonly IMapper _mapper;

        public MauHopDongLaoDongController(IMauHopDongRepository mauHopDongRepository,
            ILoaiHopDongRepository loaiHopDongRepository,
            IWebHostEnvironment webHostEnvironment,
            UserManager<Employee> userManager,
            IMapper mapper)
        {
            _mauHopDongRepository = mauHopDongRepository;
            this.loaiHopDongRepository = loaiHopDongRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            _mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {
            var mauHopDongs = await _mauHopDongRepository.FindAll();
            var model = new HomeIndexMauHopDongVM
            {
                mauHopDongVMs = _mapper.Map<ICollection<MauHopDongVM>>(mauHopDongs),
                EmployeeVMs = _mapper.Map<IEnumerable<EmployeeVM>>(await userManager.Users.ToListAsync())
            };
            return View(model);
        }

 
        public async Task<IActionResult> CreateMauHopDong ()
        {

            var model = new CreateEditMauHopDongVM();
            model = await AddLoaiHopDongToCreateEditMauHopDongVM(model);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMauHopDong (CreateEditMauHopDongVM model)
        {
            model = await AddLoaiHopDongToCreateEditMauHopDongVM(model);


            if (!ModelState.IsValid)
            {
                return View();
            }

            var mauHopDongMoi = _mapper.Map<MauHopDong>(model);
            mauHopDongMoi.MaNhanVienLuuMauHopDong = userManager.GetUserAsync(HttpContext.User).Result.Id;
            mauHopDongMoi.NgayGuiMauHopDong = DateTime.Now;
            mauHopDongMoi.ViTriLuuMauHopDong = UploadMauHopDongLaoDong(model);
            mauHopDongMoi.MaMauHopDong = Guid.NewGuid().ToString();

            if (mauHopDongMoi.ViTriLuuMauHopDong==null)
            {
                ModelState.AddModelError("", "Error while uploading the MauHopDongFile");
            }

            bool IsSuccess = await _mauHopDongRepository.Create(mauHopDongMoi);
            if (!IsSuccess)
            {
                ModelState.AddModelError("", "error while creating MauHopDong Record on database");
                return View();
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> EditMauHopDong(string id)
        {

            //if (!(await _leaveTypeRepository.isExist(id)))
            //{
            //    return NotFound();
            //}
            //var leavetype = await _leaveTypeRepository.FindById(id);
            //var model = _mapper.Map<LeaveTypeVM>(leavetype);

            if (!(await _mauHopDongRepository.isExist(id)))
            {
                return NotFound();
            }

            var mauHopDong = await _mauHopDongRepository.FindById(id);
            var model = _mapper.Map<CreateEditMauHopDongVM>(mauHopDong);
            model = await AddLoaiHopDongToCreateEditMauHopDongVM(model);


            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMauHopDong(CreateEditMauHopDongVM model)
        {
            try
            {
                model = await AddLoaiHopDongToCreateEditMauHopDongVM(model);
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var mauHopDong = _mapper.Map<MauHopDong>(model);

                var uriMauHopDongFile = UploadMauHopDongLaoDong(model);
                if (uriMauHopDongFile != null)
                {
                    var oldMauHopDongName = mauHopDong.ViTriLuuMauHopDong;
                    mauHopDong.ViTriLuuMauHopDong = uriMauHopDongFile;
                    DeleteFileMauHopDong(oldMauHopDongName);
                }
                mauHopDong.MaNhanVienChinhSuaLanCuoi =  userManager.GetUserAsync(HttpContext.User).Result.Id;
                mauHopDong.ThoiGianChinhSuaLanCuoi = DateTime.Now;

                var isSuccess = await _mauHopDongRepository.Update(mauHopDong);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> DetailsMauHopDong(string id)
        {
            var mauHopDong = await _mauHopDongRepository.FindById(id);
            var model = _mapper.Map<MauHopDongVM>(mauHopDong);

            return View(model);
        }

        // GET: LeaveRequestController/Delete/5
        public async Task<ActionResult> DeleteMauHopDong(string id)
        {
            var mauHopDong = await _mauHopDongRepository.FindById(id);
            if (mauHopDong == null)
            {
                return NotFound();
            }
            var isSuccess = await _mauHopDongRepository.Delete(mauHopDong);

            if (!isSuccess)
            {
                return BadRequest();
            }
            DeleteFileMauHopDong(mauHopDong.ViTriLuuMauHopDong);


            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DownloadMauHopDongLaoDong(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           @"wwwroot\mauHopDongLaoDongs", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private async Task<CreateEditMauHopDongVM> AddLoaiHopDongToCreateEditMauHopDongVM(CreateEditMauHopDongVM model)
        {
            var loaihopdongs = (await loaiHopDongRepository.FindAll())
                .Select(q => new SelectListItem()
                {
                    Text = q.TenLoai,
                    Value = q.MaLoaiHopDong
                });

            model.LoaiHopDongs = loaihopdongs;

            return model;
        }

        private string UploadMauHopDongLaoDong(CreateEditMauHopDongVM model)
        {
            string uniqueFileName = null;

            if (model.FileMauHopDong != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "mauHopDongLaoDongs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileMauHopDong.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FileMauHopDong.CopyTo(fileStream);
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

        private void DeleteFileMauHopDong(string fileName)
        {


            if (fileName != null)
            {
                string mauHopDongLaoDongFilePath = Path.Combine(webHostEnvironment.WebRootPath, "mauHopDongLaoDongs", fileName);
                System.IO.File.Delete(mauHopDongLaoDongFilePath);
            }

        }
    }
}
