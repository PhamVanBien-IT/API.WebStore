using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Enums.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int? totalRecord { get; set; }
        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int? totalPage { get; set; }
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object? Data { get; set; }
    }
}
