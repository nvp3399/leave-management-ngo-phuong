using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Tên")]
        public string Firstname { get; set; }
        [DisplayName("Họ")]
        public string LastName { get; set; }
        [DisplayName("Mã số thuế")]
        public string TaxtId { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Ngày gia nhập")]
        public DateTime DateJoined { get; set; }
    }
}
