using DemoShop.DataLayer.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
	public interface IUserService: IAsyncDisposable
	{
		#region Account

		Task<RegisterUserResult> RegisterUser(RegisterUserDTO register);
		Task<bool> IsUserExistsByMobileNumber(string mobileNumber);

		#endregion
	}
}
