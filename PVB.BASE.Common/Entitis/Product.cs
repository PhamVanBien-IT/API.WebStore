using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Mã không được để trống")]
        [DisplayName("Mã sản phẩm")]
        [RegularExpression(@"SP-[0-9]{5,17}\b")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [Required(ErrorMessage = "Tên không được để trống")]
        public string FullName { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gía
        /// </summary>
        [Required(ErrorMessage = "Giá không được để trống")]
        public int? Price { get; set; }

        /// <summary>
        /// Kích thước
        /// </summary>
        [Required(ErrorMessage = "Size không được để trống")]
        public string? Size { get; set; }

        /// <summary>
        /// Màu sắc
        /// </summary>
        [Required(ErrorMessage = "Màu không được để trống")]
        public string? Color { get; set; }

        /// <summary>
        /// Ảnh
        /// </summary>
        //[Required(ErrorMessage = "Ảnh không được để trống")]
        public string? Image { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string? Description { get; set; }

        /// <summary>
        /// Id danh mục
        /// </summary>
        public Guid CategoryId { get; set;}

        /// <summary>
        /// Id danh mục
        /// </summary>
        public string CategoryName { get; set; }

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
        public string? CreatedBy { get; set;}

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set;}

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set;}
    }
}
