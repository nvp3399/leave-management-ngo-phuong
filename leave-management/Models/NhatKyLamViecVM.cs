using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class NhatKyLamViecVM
    {
        public IEnumerable<LichSuChamCongVM> LichSuChamCongVMs { get; set; }
        public IEnumerable<LeaveRequestVM> LeaveRequestVMs { get; set; }

        public EmployeeVM NhanVien { get; set; }
    }
}
