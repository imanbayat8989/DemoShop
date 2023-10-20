using DemoShop.DataLayer.DTO.Account;
using DemoShop.DataLayer.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
	public interface IUserService : IAsyncDisposable
	{
		#region Account

		Task<RegisterUserResult> RegisterUser(RegisterUserDTO register);
		Task<bool> IsUserExistsByMobileNumber(string mobileNumber);
		Task<LoginUserResult> GetUserForLogin(LoginUserDTO loginUser);
		Task<User> GetUserByMobile(string mobileNumber);
		Task<ForgotPasswordResult> RecoverUserPassword(ForgotPasswordDTO forgotPassword);

		#endregion
	}
}
