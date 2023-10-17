using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Account;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
	public class UserService : IUserService
	{
		#region Constructor
		private readonly IGenericRepository<User> _userRepository;
		private readonly IPasswordHelper _passwordHelper;

		public UserService(IGenericRepository<User> userRepository, IPasswordHelper passwordHelper)
		{
			_userRepository = userRepository;
			_passwordHelper = passwordHelper;
		}

		#endregion

		#region Account

		public async Task<RegisterUserResult> RegisterUser(RegisterUserDTO register)
		{
			try
			{
				if (!await IsUserExistsByMobileNumber(register.Mobile))
				{
					var user = new User
					{
						FirstName = register.FirstName,
						LastName = register.LastName,
						Mobile = register.Mobile,
						Email = register.Email,
						Password = _passwordHelper.EnCodePasswordMD5(register.Password),
						MobileActiveCode = new Random().Next(10000, 999999).ToString(),
						EmailActiveCode = Guid.NewGuid().ToString("N")
					};
					await _userRepository.AddEntity(user);
					await _userRepository.SaveChanges();

					return RegisterUserResult.Success;
				}
				else
				{
					return RegisterUserResult.MobileExists;
				}
			}
			catch (Exception ex)
			{
				return RegisterUserResult.Error;
			}
			return RegisterUserResult.Success;
		}

		#endregion

		public async ValueTask DisposeAsync()
		{
			await _userRepository.DisposeAsync();
		}

		public async Task<bool> IsUserExistsByMobileNumber(string mobileNumber)
		{
			return await _userRepository.GetQuery().AsQueryable().AnyAsync(s => s.Mobile == mobileNumber);
		}

		public async Task<LoginUserResult> GetUserForLogin(LoginUserDTO loginUser)
		{
			var user = await _userRepository.GetQuery().AsQueryable()
				.SingleOrDefaultAsync(x => x.Mobile == loginUser.Mobile);
			if (user == null)
			{
				return LoginUserResult.NotFound;
			}
			if (!user.IsMobileActive)
			{
				return LoginUserResult.NotActiveted;
			}
			if (user.Password != _passwordHelper.EnCodePasswordMD5(loginUser.Password)) return LoginUserResult.NotFound;
			return LoginUserResult.Success;
		}

		public async Task<User> GetUserByMobile(string mobileNumber)
		{
			return await _userRepository.GetQuery().AsQueryable().SingleOrDefaultAsync(x => x.Mobile == mobileNumber);
		}
	}
}
