using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Order
    {
        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Địa chỉ đơn hàng
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Phương thức thanh toán
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Id người dùng
        /// </summary>
        public Guid CustomerId { get; set; }

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
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set;}
    }
}
