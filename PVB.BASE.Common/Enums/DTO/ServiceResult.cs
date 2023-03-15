using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Enums.DTO
{
    public class ServiceResult
    {
        /// <summary>
        /// Kết quả validate: tru là không có lỗi, false là có lỗi
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Danh sách lỗi
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        ///  Thông báo lỗi
        /// </summary>
        public string? Message { get; set; }
    }
}
