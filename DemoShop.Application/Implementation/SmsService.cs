using DemoShop.Application.Interface;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
	public class SmsService : ISmsService
	{
		private string apiKey = "sLI6vchWcpoCesrsdrLvj22ZaXeafctpKuv2GRQC406tUev0cxt7N4IOCxPAI8BU";

        public async Task SendUserPassword(string mobile, string Password)
        {
            SmsIr smsIr = new SmsIr(apiKey);

            var bulkSendResult = await smsIr.VerifySendAsync(mobile, 10000, new VerifySendParameter[] { new("Code", Password) });
        }

        public async Task SendVerificationSms(string mobile, string ActivationCode)
		{
			SmsIr smsIr = new SmsIr(apiKey);

			var bulkSendResult = await smsIr.VerifySendAsync(mobile,10000,new VerifySendParameter[] { new ("Code" , ActivationCode) });

			
		}
	}
}
