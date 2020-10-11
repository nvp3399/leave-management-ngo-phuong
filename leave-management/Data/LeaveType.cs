using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DefaultDays { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public string Comments { get; set; }

        [ForeignKey("MaNhanVienTao")]
        public Employee NhanVienTao { get; set; }
        public string MaNhanVienTao { get; set; }

    }
}
