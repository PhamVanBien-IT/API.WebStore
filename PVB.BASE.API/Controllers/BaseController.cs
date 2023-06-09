﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVB.BASE.BL;
using PVB.BASE.Common;
using PVB.BASE.Common.Enums.DTO;
using System;

namespace PVB.BASE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;

        }
        #endregion

        #region Method
        /// <summary>
        /// API lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: Bien (15/03/2023)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _baseBL.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.UnknownError,
                    MsgDev = ex.Message,
                    MsgUser= Common.Resource.ErrorMsg,
                    TraceId = GetHttpContext().TraceIdentifier
                }) ;
            }
        }

        /// <summary>
        /// API tìm theo tên và mã rồi phân trang
        /// </summary>
        /// <param name="filter">Tên và mã đối tượng muốn tìm</param>
        /// <param name="deparmentId">ID đơn vị</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="pageNumber">Đánh số trang hiên tại</param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: Bien (6/2/2023)
        [HttpGet]
        [Route("filter")]
        public IActionResult Filter(
            [FromQuery] string? filter,
            [FromQuery] string? categoryName,
            [FromQuery] int offSet = 0,
            [FromQuery] int liMit = 20
            )
        {
            try
            {
                // Gọi hàm tìm kiếm trong BaseBL
                var data = _baseBL.Filter(filter, categoryName,liMit,offSet);
                return Ok(data);
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

        /// <summary>
        /// API lấy đối tượng theo id
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn lấy</param>
        /// <returns>Đối tượng có id tương ứng</returns>
        /// CreatedBy: Bien (6/2/2023)
        [HttpGet("{entityId}")]

        public IActionResult GetById([FromRoute] Guid entityId)
        {
            try
            {
                // Gọi vào hàm lấy đối tượng theo id trong BaseBL
                var data = _baseBL.GetById(entityId);
                return Ok(data);
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

        /// <summary>
        /// Hàm khởi tạo TraceId
        /// </summary>
        /// <returns></returns>
        protected HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        /// <summary>
        /// API thêm mới
        /// </summary>
        /// <param name="entity">Đối tượng muốn thêm mới</param>
        /// <returns>
        /// 201: Nếu thêm mới thành công
        /// 404: Nếu thêm thất bại
        /// 500: Nếu gặp lỗi trycatch
        /// </returns>
        /// CreatedBy: Bien (6/2/2023)
        [HttpPost]
        public virtual IActionResult Insert([FromBody] T entity)
        {
            try
            {
                // Gọi vào thêm xóa trong BaseBL
                var data = _baseBL.Insert(entity);

                if (data.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, data);
                }
                else
                {
                    return BadRequest(new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ValidateError,
                        MsgDev = Common.Resource.ErrorMsg_Validate,
                        MoreInfo = data.Data,
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

        /// <summary>
        /// API Sửa
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn sửa</param>
        /// <param name="entity">Đối tượng mang dữ liệu mới</param>
        /// <returns>
        /// 201: Nếu thêm mới thành công
        /// 404: Nếu thêm thất bại
        /// 500: Nếu gặp lỗi trycatch
        /// </returns>
        [HttpPut("{entityId}")]
        public virtual IActionResult Update([FromRoute] Guid entityId, [FromBody] T entity)
        {
            try
            {
                // Gọi vào thêm xóa trong BaseBL
                var data = _baseBL.Update(entityId, entity);

                if (data.IsSuccess)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest(new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ValidateError,
                        MsgDev = Common.Resource.ErrorMsg_Validate,
                        MoreInfo = data.Data,
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

        /// <summary>
        /// API xóa
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn xóa</param>
        /// <returns>
        /// 1: Nếu xóa thành công
        /// 0: Nếu xóa thất bại
        /// </returns>
        /// CreatedBy: Bien (17/1/2023)
        [HttpDelete("{entityId}")]
        public virtual IActionResult Delete([FromRoute] Guid entityId)
        {
            try
            {
                // Gọi vào hàm xóa trong BaseBL
                var data = _baseBL.Delete(entityId);
                return Ok(data);
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

        /// <summary>
        /// API xóa nhiều bản ghi
        /// </summary>
        /// <param name="entityIds">Danh sách id bản ghi muốn xóa</param>
        /// <returns>
        /// 200: Nếu xóa thành công
        /// 500: Nếu lỗi try catch
        /// </returns>
        [HttpDelete]
        public IActionResult Deletes([FromBody] List<Guid> entityIds)
        {
            try
            {
                // Gọi vào hàm xóa trong BaseBL
                var data = _baseBL.Deletes(entityIds);
                return Ok(data);
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

        /// <summary>
        /// API sinh mã mới
        /// </summary>
        /// <returns>Sinh mới mã</returns>
        /// CreatedBy: Bien (17/1/2023)
        [HttpGet("newCode")]
        public IActionResult NewCode()
        {
            try
            {
                var data = _baseBL.NewCode();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = PVB.BASE.Common.Enums.ErrorCode.UnknownError,
                    MsgDev = ex.Message,
                    MsgUser = Resource.ErrorMsg,
                });
            }
        }
        #endregion
    }
}
