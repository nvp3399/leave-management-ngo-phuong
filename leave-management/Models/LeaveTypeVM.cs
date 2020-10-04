using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Tên")]
        public string Name { get; set; }

        [Required]
        [Display(Name= "Số ngày mặc định")]
        [Range(1,25, ErrorMessage ="Vui lòng nhập số ngày hợp lệ")]
        public int DefaultDays { get; set; }

        [Display(Name="Ngày tạo")]
        public DateTime? DateCreated { get; set; }

        [Display(Name="Ghi chú")]
        public string Comments { get; set; }
    }

   
}
