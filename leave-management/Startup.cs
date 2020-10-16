using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using leave_management.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using leave_management.Contracts;
using leave_management.Repository;
using AutoMapper;
using leave_management.Mappings;

namespace leave_management
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AzureConnection")));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            }

            services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();




            //Add reference for Repository and Contracts to Startup file
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<IChucVuRepository, ChucVuRepository>();
            services.AddScoped<IChuyenMonRepository, ChuyenMonRepository>();
            services.AddScoped<IPhongBanRepository, PhongBanRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMauHopDongRepository, MauHopDongRepository>();
            services.AddScoped<ILoaiHopDongRepository, LoaiHopDongRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IHopDongLaoDongRepository, HopDongLaoDongRepository>();

            services.AddScoped<IGiayToTuyThanRepository, GiayToTuyThanRepository>();
            services.AddScoped<ILoaiGiayToTuyThanRepository, LoaiGiayToTuyThanRepository>();
            services.AddScoped<ILoaiLichBieuRepository, LoaiLichBieuRepository>();
            services.AddScoped<ILuongTheoThangRepository, LuongTheoThangRepository>();
            services.AddScoped<INhatKylamViecRepository, NhatKyLamViecRepository>();
            services.AddScoped<IPhieuChi_TamUngLuongRepository, PhieuChi_TamUngLuongRepository>();
            services.AddScoped<IYeuCauDatLuongCoBanRepository, YeuCauDatLuongCoBanRepository>();
            services.AddScoped<IYeuCauTamUngLuongRepository, YeuCauTamUngLuongRepository>();

            services.AddScoped<IPhieuChi_LuongCuoiThangRepository, PhieuChi_LuongCuoiThangRepository>();
            services.AddScoped<IPhieuChi_TamUngLuongRepository, PhieuChi_TamUngLuongRepository>();
            services.AddScoped<IPhieuChi_NKLVRepository, PhieuChi_NKLVRepository>();
            
            services.AddAutoMapper(typeof(Maps));

            services.AddDefaultIdentity<Employee>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>();
            /*
            services.AddDbContext<leave_managementContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("leave_managementContext")));
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            SeedData.Seed(userManager, roleManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
