using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Supplier
    {
        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Địa chỉ nhà cung cấp
        /// </summary>
        public string Address { get; set;}

        /// <summary>
        /// Số điện thoại 
        /// </summary>
        public string PhoneNumber { get; set;}

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set;}

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set;}

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set;}

        /// <summary>
        /// Ngưởi sửa
        /// </summary>
        public string ModifiedBy { get; set;}
    }
}
