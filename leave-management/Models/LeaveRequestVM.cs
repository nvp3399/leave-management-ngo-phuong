using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }

        [DisplayName("Nhân viên")]

        public EmployeeVM RequestingEmployee { get; set; }

        [DisplayName("Nhân viên")]
        public string RequestingEmployeeId { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        [DisplayName("Loại nghỉ phép")]
        public LeaveTypeVM LeaveType { get; set; }
        
        [DisplayName("Ngày gửi yêu cầu")]
        public DateTime DateRequested { get; set; }

        [DisplayName("Ngày duyệt")]
        public DateTime DateActioned { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Approved { get; set; }
        public EmployeeVM ApproveBy { get; set; }
        public string ApprovedById { get; set; }

        public bool Cancelled { get; set; }
    }

    public class AdminLeaveRequestViewVM
    {
        [DisplayName("Tổng các yêu cầu")]
        public int TotalRequests { get; set; }
        [DisplayName("Yêu cầu được chấp thuận")]
        public int ApprovedRequets { get; set; }
        [DisplayName("Yêu cầu đang chờ")]
        public int PendingRequests { get; set; }
        [DisplayName("Yêu cầu bị từ chối")]
        public int RejectedRequests { get; set; }

        [DisplayName("Yêu cầu bị hủy")]
        public int CancelledRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
        public PhongBansVM PhongBan { get; set; }
        public EmployeeVM TruongPhong { get; set; }
    }

    public class CreateLeaveRequestVM
    {
        [DisplayName("Ngày bắt đầu")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [DisplayName("Loại nghỉ phép")]
        public int LeaveTypeId { get; set; }

    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveRequestVM> LeaveRequests { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }

        public List<LeaveTypeVM> LeaveTypesInfo { get; set; }
    }
}
