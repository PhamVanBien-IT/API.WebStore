using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.Common.Constants
{
    public class ProcedureName
    {
        /// <summary>
        /// Template cho produre lấy tất cả bản ghi
        /// </summary>
        public static string PROC_GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Template cho procedure tìm kiếm và phân trang 
        /// </summary>
        public static string PROC_GET_BY_FILTER = "Proc_{0}_GetByFilter";

        /// <summary>
        /// Template cho procedure lấy bản ghi theo ID
        /// </summary>
        public static string PROC_GET_BY_ID = "Proc_{0}_GetById";

        /// <summary>
        /// Template cho procedure thêm mới bản ghi 
        /// </summary>
        public static string PROC_INSERT = "Proc_{0}_Insert";

        /// <summary>
        /// Template cho procedure sửa bản ghi 
        /// </summary>
        public static string PROC_UPDATE = "Proc_{0}_Update";

        /// <summary>
        /// Template cho procedure xóa  bản ghi 
        /// </summary>
        public static string PROC_DELETE = "Proc_{0}_Delete";

        /// <summary>
        /// Template cho procedure xuất khẩu
        /// </summary>
        public static string PROC_EXPORT = "Proc_{0}_ExportExcel";

        /// <summary>
        /// Template cho procdure xóa nhiều bản ghi
        /// </summary>
        public static string PROC_DELETES = "Proc_{0}_Deletes";

        /// <summary>
        /// Template cho produre sinh mã mới
        /// </summary>
        public static string PROC_GETMAXCODE = "Proc_{0}_GetMaxCode";

        /// <summary>
        /// Template cho produre check trùng mã
        /// </summary>
        public static string PROC_CHECKCODE = "Proc_{0}_GetByCode";
    }
}
