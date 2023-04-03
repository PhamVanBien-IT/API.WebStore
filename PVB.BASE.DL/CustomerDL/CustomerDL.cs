using Dapper;
using PVB.BASE.Common.Database;
using PVB.BASE.Common.Entitis;
using PVB.BASE.Common.Enums.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.DL.CustomerDL
{
    public class CustomerDL : BaseDL<Customer>, ICustomerDL
    {
        public CustomerDL(IDatabase database) : base(database)
        {
        }

        /// <summary>
        /// API đăng nhập
        /// </summary>
        /// <param name="customer">Thông tin đăng nhập</param>
        /// <returns>Thông tin đăng nhập</returns>
        /// CreatedBy: Bien (31/03/2023)
        public Customer Login(Customer customer)
        {
            // Khai báo tên class
            var customerName = typeof(Customer).Name;

            // Khai báo tên stored procedure
            string storedProdureName = "Proc_Login";

            // Chuẩn bị tham số đầu vào cho stored
            var parameters = new DynamicParameters();
            parameters.Add("p_PhoneNumber", customer.PhoneNumber);
            parameters.Add("p_Password", customer.Password);

            // Gọi vào DB
            using (var connection = _database.CreateConnection())
            {
                connection.Open();

                var data = connection.QueryFirstOrDefault<Customer>(storedProdureName, parameters, commandType: CommandType.StoredProcedure);

                return data;
            }

        }
    }
}
