using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Product
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Mã sản phâm
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gía
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Ảnh
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Kích thước
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Màu sắc
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Id danh mục
        /// </summary>
        public Guid CategoryId { get; set;}

        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public Guid SupplierId { get; set; }

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
