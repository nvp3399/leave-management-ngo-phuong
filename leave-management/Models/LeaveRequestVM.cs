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

        public EmployeeVM RequestingEmployee { get; set; }

        [DisplayName("Employee Name")]
        public string RequestingEmployeeId { get; set; }

        [DisplayName("Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        [DisplayName("Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }
        
        [DisplayName("Date Requested")]
        public DateTime DateRequested { get; set; }

        [DisplayName("Date Actioned")]
        public DateTime DateActioned { get; set; }

        [DisplayName("Approved State")]
        public bool? Approved { get; set; }
        public EmployeeVM ApproveBy { get; set; }
        public string ApprovedById { get; set; }

        public bool Cancelled { get; set; }
    }

    public class AdminLeaveRequestViewVM
    {
        [DisplayName("Total Requests")]
        public int TotalRequests { get; set; }
        [DisplayName("Approved Requests")]
        public int ApprovedRequets { get; set; }
        [DisplayName("Pending Requests")]
        public int PendingRequests { get; set; }
        [DisplayName("Rejected Requests")]
        public int RejectedRequests { get; set; }

        [DisplayName("Cancelled Requests")]
        public int CancelledRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }

    public class CreateLeaveRequestVM
    {
        [DisplayName("Start Date")]
        [Required]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [DisplayName("Leave Type")]
        public int LeaveTypeId { get; set; }

    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveRequestVM> LeaveRequests { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }

        public List<LeaveTypeVM> LeaveTypesInfo { get; set; }
    }
}
