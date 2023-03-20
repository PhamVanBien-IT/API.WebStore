using Microsoft.AspNetCore.Mvc;
using PVB.BASE.Common.Enums.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// API lấy tất cả 
        /// </summary>
        /// <returns>Danh sách tất cả đối tượng</returns>
        /// CreatedBy: Bien (15/03/2023)
        public List<T> GetAll();

        /// <summary>
        /// API tìm kiếm đối tượng theo tên và mã
        /// </summary>
        /// <param name="filter">Tên nhân viên và mã đối tượng cần tìm kiếm</param>
        /// <param name="deparmentId">Id department muốn tìm</param>
        /// <param name="pageSize">Kích thước trong 1 bảng ghi</param>
        /// <param name="pageNumber">Số thứ tự hiện tại của trang</param>
        /// <returns>Danh sách đối tượng</returns>
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
        public T GetById(Guid entityId);

        /// <summary>
        /// Hàm thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>
        /// 1. Nếu thêm thành công 
        /// 0. Nếu thêm thất bại
        /// </returns>
        /// CretaedBy: Bien (6/2/2023)
        public int Insert(T entity);

        /// <summary>
        /// API Sửa
        /// </summary>
        /// <param name="entityId">Id của đối tượng muốn sửa</param>
        /// <param name="entity">Đối tượng mang giá trị đã được thay đổi</param>
        /// <returns> 
        /// 1. Nếu sửa thành công,
        /// 0. Nếu sửa thất bại
        /// </returns>
        /// CreatedBy: Bien (6/2/2023)
        public int Update([FromRoute] Guid entityId, [FromBody] T entity);

        /// <summary>
        /// API Xóa
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn xóa</param>
        /// <returns>
        ///  1.Nếu xóa thành công,
        ///  0.Nếu xóa thất bại
        /// </returns>
        /// CreatedBy: Bien (6/2/2023)
        public int Delete([FromRoute] Guid entityId);

        /// <summary>
        /// API xuất dữ liệu sang file Excel
        /// </summary>
        /// <returns>File Excel chứa dữ liệu</returns>
        public ServiceResult ExportToExcel(string? filter);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entityIds">Danh sách id bản ghi muốn xóa</param>
        /// <returns>
        /// 1: Nếu xóa thành công
        /// 0: Nếu xóa thất bại
        /// </returns>
        /// CreatedBy: Bien (24/02/2023)
        public int Deletes(List<Guid> entityIds);

        /// <summary>
        /// API Sinh mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: Bien (24/02/2023)
        public string GetMaxCode();

        /// <summary>
        /// API kiểm tra trùng mã
        /// </summary>
        /// <returns>
        /// Id đối tượng
        /// </returns>
        /// CreatedBy: Bien (20/03/2023)
        public Guid CheckCode(string entityCode);
    }
}
