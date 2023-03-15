using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Customer
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Đia chỉ người dùng
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Quyền truy cập
        /// </summary>
        public int Access { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set;}

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set;}

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set;}
    }
}
