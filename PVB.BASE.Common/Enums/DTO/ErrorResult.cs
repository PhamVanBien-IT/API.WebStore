using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Enums.DTO
{
    public class ErrorResult
    {

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode? ErrorCode { get; set; }

        /// <summary>
        /// Thông báo lỗi dev
        /// </summary>
        public string? MsgDev { get; set; }

        /// <summary>
        /// Thông báo lỗi user
        /// </summary>
        public string? MsgUser { get; set; }

        /// <summary>
        /// Thông tin lỗi chia tiết
        /// </summary>
        public object? MoreInfo { get; set; }

        /// <summary>
        /// Mã truy vết lỗi
        /// </summary>
        public string? TraceId { get; set; }
    }
}
