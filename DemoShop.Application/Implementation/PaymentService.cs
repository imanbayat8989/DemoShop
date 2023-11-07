using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
    public class PaymentService : IPaymentService
    {
        public PaymentStatus CreatePaymentRequest(string merchantId, int amount, string description, string callbackUrl,
            ref string redirectUrl, string userEmail, string userMobile)
        {
            var payment = new ZarinpalSandbox.Payment(amount);
            var res = payment.PaymentRequest(description, callbackUrl, userEmail, userMobile);

            if (res.Result.Status == (int)PaymentStatus.St100)
            {
                redirectUrl = "https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority;
                return (PaymentStatus)res.Result.Status;
            }

            return (PaymentStatus)res.Status;
        }
    }
}
