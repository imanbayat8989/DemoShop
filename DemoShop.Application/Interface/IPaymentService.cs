using DemoShop.DataLayer.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface IPaymentService
    {
        PaymentStatus CreatePaymentRequest(string merchantId, int amount, string description,
       string callbackUrl, ref string redirectUrl, string userEmail, string userMobile);
    }
}
