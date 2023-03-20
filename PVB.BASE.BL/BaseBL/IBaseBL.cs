using Microsoft.AspNetCore.Mvc;
using PVB.BASE.Common.Enums.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PVB.BASE.BL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// API lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả đối tượng</returns> 
        /// CreatedBy: Bien (15/03/2023)
        public ServiceResult GetAll();

        /// <summary>
        /// API tìm kiếm nhân viên theo tên và mã
        /// </summary>
        /// <param name="filter">Tên nhân viên và mã nhân viên cần tìm kiếm</param>
        /// <param name="deparmentId">Id department muốn tìm</param>
        /// <param name="positionId">Id position muốn tìm</param>
        /// <param name="pageSize">Kích thước trong 1 bảng ghi</param>
        /// <param name="pageNumber">Số thứ tự hiện tại của trang</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: Bien (17/1/2023)
        public PagingResult Filter([FromQuery] string? filter,
            [FromQuery] string? categoryName,
            [FromQuery] int offSet = 0,
            [FromQuery] int liMit = 20
            );

        /// <summary>
        /// Lấy 1 bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của bản ghi muốn lấy</param>
        /// <returns>Đối tượng muốn lấy</returns>
        /// CreatedBy: Bien (6/2/2023)
        public ServiceResult GetById(Guid entityId);

        /// <summary>
        /// Hàm thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần thêm mới</param>
        /// <returns>
        /// 1. Nếu thêm thành công 
        /// 0. Nếu thêm thất bại
        /// </returns>
        /// CretaedBy: Bien (6/2/2023)
        public ServiceResult Insert(T entity);

        /// <summary>
        /// API sửa
        /// </summary>
        /// <param name="entityId">Id của đối tượng muốn sửa</param>
        /// <param name="entity">Đối tượng mang giá trị đã được thay đổi</param>
        /// <returns> Kết quả của hành động sửa nếu: 1.Sửa thành công, -1. Sửa thất bại</returns>
        /// CreatedBy: Bien (17/1/2023)
        public ServiceResult Update([FromRoute] Guid entityId, [FromBody] T entity);

        /// <summary>
        /// API Xóa
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn xóa</param>
        /// <returns>
        ///  1.Xóa nếu thành công,
        ///  0. Xóa nếu thất bại
        /// </returns>
        public ServiceResult Delete([FromRoute] Guid entityId);

        /// <summary>
        /// API xuất dữ liệu sang file Excel
        /// </summary>
        /// <returns>File Excel chứa dữ liệu</returns>
        public ServiceResult ExportToExcel(string filter);

        /// <summary>
        /// API xóa nhiều bản ghi
        /// </summary>
        /// <param name="entityIds">Danh sách Id muốn xóa</param>
        /// <returns>
        ///  1.Xóa nếu thành công,
        ///  0. Xóa nếu thất bại
        ///  </returns>
        public ServiceResult Deletes(List<Guid> entityIds);

        /// <summary>
        /// API Sinh mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: Bien (20/03/2023)
        public ServiceResult NewCode();

        /// <summary>
        /// API kiểm tra trùng mã 
        /// </summary>
        /// <returns>
        /// True: Nếu mã đã tồn tại
        /// False: Nếu mã hợp lệ
        /// </returns>
        /// CreatedBy: Bien (20/03/2023)
        public bool CheckCode(T entity, bool isInsert = true);
    }
}
