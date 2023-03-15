using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Text.RegularExpressions;
using System.ComponentModel;
using PVB.BASE.DL;
using PVB.BASE.Common.Enums.DTO;
using PVB.BASE.Common;

namespace PVB.BASE.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        public object Resource { get; private set; }

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// API lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: Bien (15/03/2023)
        public ServiceResult GetAll()
        {
            // Khai báo biến nhận kết quả trả về
            ServiceResult serviceResult = new ServiceResult();
            var data = _baseDL.GetAll();

            if(data != null )
            {
                serviceResult.IsSuccess = true;
                serviceResult.Data = data;
            }
            else
            {
                serviceResult.IsSuccess = false;
            }

            return serviceResult;
        }

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng được validate</param>
        /// <returns>
        /// Danh sách lỗi
        /// </returns>
        /// CreatedBy: Bien (12/2/2023)
        protected virtual Dictionary<string, string> Validate(T? entity, bool isInsert = true)
        {
            var result = ValidateCustom(entity, isInsert);

            var properties = typeof(T).GetProperties();

            // Kiểm tra xem property nào có attribute là Requidred
            var validateFailures = new Dictionary<string, string>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);

                // Kiểm tra lỗi để trống dữ liệu
                var requiredAttribute = (RequiredAttribute?)property.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();

                if (requiredAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    validateFailures.Add(propertyName, requiredAttribute.ErrorMessage);
                }

                // Kiểu tra lỗi không đúng định dạng 
                var displayAtrribute = (DisplayNameAttribute?)property.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
                var regularAttribute = (RegularExpressionAttribute?)property.GetCustomAttributes(typeof(RegularExpressionAttribute), false).FirstOrDefault();
                if (regularAttribute != null)
                {
                    if (propertyValue != null && propertyValue != "")
                    {
                        var pattern = regularAttribute.Pattern;
                        var isMatch = Regex.Match(propertyValue.ToString(), pattern, RegexOptions.IgnoreCase);
                        if (!isMatch.Success)
                        {
                            validateFailures.Add(propertyName, displayAtrribute.DisplayName + PVB.BASE.Common.Resource.ErrorMsg_CustomValidate);
                        }
                    }
                }
            } 
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    validateFailures.Add(item.Key, item.Value);
                }
            }

            return validateFailures;
        }

        /// <summary>
        /// Hàm kiểm tra những lỗi riêng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual Dictionary<string, string> ValidateCustom(T? entity, bool isInsert = true)
        {
            var validateFailures = new Dictionary<string, string>();
       
            return validateFailures;
        }

        /// <summary>
        /// API tìm kiếm nhân viên theo tên và mã
        /// </summary>
        /// <param name="filter">Tên nhân viên và mã nhân viên cần tìm kiếm</param>
        /// <param name="deparmentId">Id department muốn tìm</param>
        /// <param name="positionId">Id position muốn tìm</param>
        /// <param name="pageSize">Kích thước trong 1 bảng ghi</param>
        /// <param name="pageNumber">Số thứ tự hiện tại của trang</param>
        /// <returns>
        /// Danh sách đối tượng
        /// </returns>
        /// CreatedBy: Bien (17/1/2023)
        public PagingResult Filter([FromQuery] string? filter,
            [FromQuery] string? categoryName,
            [FromQuery] int offSet = 0,
            [FromQuery] int liMit = 20)
        {
            // Gọi vào hàm tìm kiếm trong BaseDL
            var data = _baseDL.Filter(filter, categoryName, liMit, offSet);

            if (data != null)
            {
                return data;
            }
            return data;
        }
       
        /// <summary>
        /// Lấy 1 bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của bản ghi muốn lấy</param>
        /// <returns>Đối tượng có id được truyền vào</returns>
        /// CreatedBy: Bien (6/2/2023)
        public ServiceResult GetById(Guid entityId)
        {
            // Gọi vào hàm lấy theo ID trong BaseDL
            var data = _baseDL.GetById(entityId);
            if (data != null)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                    ErrorCode = PVB.BASE.Common.Enums.ErrorCode.NoError,
                    Data = data
                };
            }
            else
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    ErrorCode = PVB.BASE.Common.Enums.ErrorCode.GetMethodByDLError,
                };
            }

        }

        /// <summary>
        /// Hàm thêm mới
        /// </summary>
        /// <param name="entity">Đối tượng nhân viên cần thêm mới</param>
        /// <returns>
        /// IsSuccess = true. Nếu thêm thành công 
        /// IsSuccess = false. Nếu thêm thất bại
        /// </returns>
        /// CretaedBy: Bien (6/2/2023)
        public virtual ServiceResult Insert(T entity)
        {
            // Khai báo biến nhận kết quả trả về
            ServiceResult serviceResult = new ServiceResult();

            // Validate dữ liệu 
            var validateResults = Validate(entity);

            if (validateResults.Count > 0)
            {
                serviceResult.IsSuccess = false;
                serviceResult.ErrorCode = PVB.BASE.Common.Enums.ErrorCode.ValidateError;
                serviceResult.Data = validateResults.ToList();
                serviceResult.Message = PVB.BASE.Common.Resource.ErrorMsg_Validate;
            }
            else
            {
                // Gọi vào DB
                var numberOfAffectedRows = _baseDL.Insert(entity);

                if (numberOfAffectedRows > 0)
                {
                    serviceResult.IsSuccess = true;
                    serviceResult.ErrorCode = PVB.BASE.Common.Enums.ErrorCode.NoError;
                }
                else
                {
                    serviceResult.IsSuccess = false;
                    serviceResult.ErrorCode = PVB.BASE.Common.Enums.ErrorCode.GetMethodByDLError;
                    serviceResult.Message = PVB.BASE.Common.Resource.ErrorMsg_InsertByDL;
                }
            }

            return serviceResult;
        }

        /// <summary>
        /// API sửa
        /// </summary>
        /// <param name="entityId">Id của đối tượng muốn sửa</param>
        /// <param name="entity">Đối tượng mang giá trị đã được thay đổi</param>
        /// <returns> 
        /// IsSuccess = true. Nếu thêm thành công 
        /// IsSuccess = false. Nếu thêm thất bại
        /// </returns>
        /// CreatedBy: Bien (17/1/2023)
        public virtual ServiceResult Update([FromRoute] Guid entityId, [FromBody] T entity)
        {
            // Khai báo biến nhận kết quả trả về
            ServiceResult serviceResult = new ServiceResult();

            // Validate dữ liệu 
            var validateResults = Validate(entity,false);

            if (validateResults.Count > 0)
            {
                serviceResult.IsSuccess = false;
                serviceResult.ErrorCode = PVB.BASE.Common.Enums.ErrorCode.ValidateError;
                serviceResult.Data = validateResults.ToList();
                serviceResult.Message = PVB.BASE.Common.Resource.ErrorMsg_Validate;
            }
            else
            {
                // Gọi vào DB
                var numberOfAffectedRows = _baseDL.Update(entityId, entity);

                if (numberOfAffectedRows > 0)
                {
                    serviceResult.IsSuccess = true;
                }
                else
                {
                    serviceResult.IsSuccess = false;
                    serviceResult.ErrorCode = PVB.BASE.Common.Enums.ErrorCode.GetMethodByDLError;
                    serviceResult.Message = PVB.BASE.Common.Resource.ErrorMsg_UpdateByDL;
                }
            }

            return serviceResult;
        }

        /// <summary>
        /// API Xóa
        /// </summary>
        /// <param name="entityId">Id của đối tượng muốn xóa</param>
        /// <returns>
        /// Kết quả của hành động xóa 
        /// 1.Nếu xóa thành công, 
        /// 0.Nếu xóa thất bại
        /// </returns>
        /// CreatedBy: Bien (12/2/2023)
        public ServiceResult Delete([FromRoute] Guid entityId)
        {
            var serviceResult = new ServiceResult();

            // Xử lý kết quả trả về
            int numberOfAffectedRows = _baseDL.Delete(entityId);

            if (numberOfAffectedRows > 0)
            {
                serviceResult.IsSuccess = true;
            }
            else
            {
                serviceResult.IsSuccess = false;
            }
            return serviceResult;
        }

        /// <summary>
        /// API xuất dữ liệu sang file Excel
        /// </summary>
        /// <returns>File Excel chứa dữ liệu</returns>
        public ServiceResult ExportToExcel(string filter)
        {
            // Gọi vào xuất dữ liệu trong BaseDL
            var data = _baseDL.ExportToExcel(filter);

            if (data.IsSuccess)
            {
                return data;
            }
            return data;
        }

        /// <summary>
        /// API xóa nhiều đối tượng
        /// </summary>
        /// <param name="entityIds">Danh sách ID đối tượng muốn xóa</param>
        /// <returns>
        /// IsSuccess: True nếu xóa thành thông
        /// IsSuccess: False nếu xóa thất bại
        /// </returns>
        public ServiceResult Deletes(List<Guid> entityIds)
        {
            var serviceResult = new ServiceResult();
            
           int numberOfAffectedRows = _baseDL.Deletes(entityIds);
            
            if (numberOfAffectedRows > 0)
            {
                serviceResult.IsSuccess = true;
            }
            else
            {
                serviceResult.IsSuccess = false;
            }
            return serviceResult;
        }

        #endregion

    }
}
