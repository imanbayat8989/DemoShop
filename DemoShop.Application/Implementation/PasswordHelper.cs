using DemoShop.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
	public class PasswordHelper : IPasswordHelper
	{
		public string EnCodePasswordMD5(string password)
		{
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;
			md5 = new MD5CryptoServiceProvider();
			originalBytes = ASCIIEncoding.Default.GetBytes(password);
			encodedBytes = md5.ComputeHash(originalBytes);
			return BitConverter.ToString(encodedBytes);

		}
	}
}
