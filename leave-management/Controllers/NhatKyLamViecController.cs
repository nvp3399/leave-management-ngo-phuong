using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

namespace leave_management.Controllers
{
    public class NhatKyLamViecController : Controller
    {
        //Ai có thể truy cập trang này: Mọi người.
        //Các trang này hiển thị gì? Trả lời: Nhật ký làm việc của chính người đó. Nhật ký này bao gồm lịch sử chấm công và các yêu cầu nghỉ phép đã được thực thi.
        //Còn gì nữa không? Tạm thời hết.

        


        /* Index là danh sách toàn bộ các nhân viên thuộc phòng ban do trưởng phòng quản lý.
         * Chỉ có vai trò trưởng phòng, trưởng phòng nhân sự, quản trị viên là truy cập được Index.
         * Cột hành động của bảng hiển thị nút xem chi tiết.
         * Khi bấm vào chi tiết hệ thống hiển thị lịch sử làm việc của nhân viên được chọn.
         * Các cột của Index là tổng hợp thống kê, cụ thể: Tổng thời gian làm việc (tính theo giờ, phút), Tổng tiền lương được tích lũy, tổng thời gian nghỉ phép tính theo giờ.
         * Đối với yêu cầu nghỉ phép được thực thi thì mỗi ngày nghỉ có tổng thời gian nghỉ phép là 8 tiếng.
         */
        // GET: NhatKyLamViecController
        public async Task<ActionResult> Index()
        {

            return View();
        }


        /* VM: NhatkylamviecVM
         * VM bao gồm 2 list.
         * List thứ nhất là lịch sử chấm công VM.
         * Hiển thị loại nhật ký làm việc là loại chấm công.
         * List thứ hai là yêu cầu nghỉ phép VM với trạng thái phê duyệt của mỗi yêu cầu là đã được chấp thuận và thời gian bắt đầu nhỏ hơn thời gian hiện tại.
         * Hiển thị loại nhật ký làm việc là nghỉ phép.
         * 
         * Bên trên: Tên & ảnh nhân viên. 
         * Bên dưới: Bảng. Có các cột sau:
         * Thời gian bắt đầu
         * Thời gian kết thúc
         * Loại nhật ký làm việc
         * 
         */
        public async Task<ActionResult> Employee(string maNhanVien)
        {
            throw new NotImplementedException();
        }

        
    }
}
