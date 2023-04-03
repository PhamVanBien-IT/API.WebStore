using PVB.BASE.Common.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.DL.CustomerDL
{
    public interface ICustomerDL : IBaseDL<Customer>
    {
        /// <summary>
        /// API đăng nhập
        /// </summary>
        /// <param name="customer">Thông tin đăng nhập</param>
        /// <returns>Thông tin đăng nhập</returns>
        /// CreatedBy: Bien (31/03/2023)
        public Customer Login(Customer customer);
    }
}
