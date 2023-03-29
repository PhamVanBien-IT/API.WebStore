using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PVB.BASE.BL;
using PVB.BASE.BL.ProductBL;
using PVB.BASE.Common.Entitis;
using PVB.BASE.Common.Enums.DTO;
using System.Drawing;

namespace PVB.BASE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product>
    {

        #region Field

        private IProductBL _productBL;

        #endregion

        #region Constractor

        public ProductsController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API xuất dữ liệu sang file Excel
        /// </summary>
        /// <returns>File Excel chứa dữ liệu</returns>
        /// CreatedBy: Bien (29/03/2023)
        [HttpGet("exportExcel")]
        public IActionResult ExportToExcel(string filter)
        {
            try
            {
                var data = _productBL.ExportToExcel(filter);

                if (data.IsSuccess)
                {
                    List<Product> employees = (List<Product>)data.Data;

                    var stream = new MemoryStream();

                    using (var xlPackage = new ExcelPackage(stream))
                    {
                        var worksheet = xlPackage.Workbook.Worksheets.Add("Danh_sach_san_pham");

                        worksheet.Row(2).Height = 20;
                        worksheet.Row(3).Height = 20;

                        worksheet.Cells["A1"].Value = "Danh sách sản phẩm";

                        // Hợp cột A1 -> J1 của dòng 1 trong sheet Danh_sach_nhan_vien
                        using (var r = worksheet.Cells["A1:J1"])
                        {
                            r.Merge = true;

                            // Định dạng kiểu chữ
                            r.Style.Font.Size = 16;
                            r.Style.Font.Bold = true;

                            // Căn chính giữa
                            r.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            r.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        using (var r = worksheet.Cells["A2:J2"])
                        {
                            r.Merge = true;
                        }
                        using (var r = worksheet.Cells["A3:J3"])
                        {
                            // Định dạng kiểu chữ
                            r.Style.Font.Size = 12;
                            r.Style.Font.Bold = true;
                            r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            r.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                            // Căn chính giữa
                            r.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            r.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            // Định dạng border
                            r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }
                        worksheet.Cells["A3"].Value = "STT";
                        worksheet.Cells["B3"].Value = "Mã sản phẩm";
                        worksheet.Cells["C3"].Value = "Tên sản phẩm";
                        worksheet.Cells["D3"].Value = "Ảnh";
                        worksheet.Cells["E3"].Value = "Số lượng";
                        worksheet.Cells["F3"].Value = "Giá tiền";
                        worksheet.Cells["G3"].Value = "Danh mục";
                        worksheet.Cells["H3"].Value = "Màu";
                        worksheet.Cells["I3"].Value = "Size";
                        worksheet.Cells["J3"].Value = "Mô tả";



                        worksheet.Column(1).Width = 6;
                        worksheet.Column(2).Width = 20;
                        worksheet.Column(3).Width = 25;
                        worksheet.Column(4).Width = 12;
                        worksheet.Column(5).Width = 20;
                        worksheet.Column(6).Width = 20;
                        worksheet.Column(7).Width = 40;
                        worksheet.Column(8).Width = 20;
                        worksheet.Column(9).Width = 20;
                        worksheet.Column(10).Width = 100;


                        int row = 4;
                        int STT = 1;
                        int start = 4;
                        int end = 4;
                        foreach (var entity in employees)
                        {
                            worksheet.Cells[row, 1].Value = STT++;
                            worksheet.Cells[row, 2].Value = entity.ProductCode;
                            worksheet.Cells[row, 3].Value = entity.FullName;
                            worksheet.Cells[row, 4].Value = entity.Image;
                            worksheet.Cells[row, 5].Value = entity.Quantity;
                            worksheet.Cells[row, 6].Value = entity.Price;
                            worksheet.Cells[row, 7].Value = entity.CategoryName;
                            worksheet.Cells[row, 8].Value = entity.Color;
                            worksheet.Cells[row, 9].Value = entity.Size;
                            worksheet.Cells[row, 10].Value = entity.Description;

                            // Tạo border 1 trường dữ liệu
                            var recordRow = worksheet.Cells["A" + start++ + ":J" + end++];

                            recordRow.Style.Font.Size = 12;
                            recordRow.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            recordRow.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            recordRow.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            recordRow.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                            row++;
                        }

                        //worksheet.Cells.AutoFitColumns();
                        worksheet.Cells.Style.Font.Name = "Arial";

                        xlPackage.Save();

                    }
                    stream.Position = 0;

                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_nhan_vien.xlsx");
                }

                else
                {
                    // Lấy danh sách thất bại
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.UnknownError,
                        MsgDev = "Lỗi khi xuất dữ liệu",
                        MsgUser = Common.Resource.ErrorMsg,
                        TraceId = GetHttpContext().TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.UnknownError,
                    MsgDev = ex.Message,
                    MsgUser = Common.Resource.ErrorMsg,
                    TraceId = GetHttpContext().TraceIdentifier
                });
            }
        }
        #endregion
    }
}
