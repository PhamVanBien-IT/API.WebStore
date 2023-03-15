using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Review
    {
        /// <summary>
        /// Id đánh giá
        /// </summary>
        public Guid ReviewId { get; set; }

        /// <summary>
        /// Nội dung đánh giá
        /// </summary>
        public string Description { get; set;}

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

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
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate{ get; set;}

        /// <summary>
        ///  Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
