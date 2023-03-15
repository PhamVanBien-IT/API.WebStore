using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Entitis
{
    public class Category
    {
        /// <summary>
        /// Id danh mục
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set;}

        /// <summary>
        /// Thời gian sửa
        /// </summary>
        public DateTime ModifiedDate { get; set;}

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set;}
    }
}
