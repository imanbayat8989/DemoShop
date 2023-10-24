using DemoShop.Application.Extensions;
using DemoShop.Application.Interface;
using DemoShop.Application.Utils;
using DemoShop.DataLayer.DTO.Account;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
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
		private readonly ISmsService _smsService;

		public UserService(IGenericRepository<User> userRepository, IPasswordHelper passwordHelper, ISmsService smsService)
		{
			_userRepository = userRepository;
			_passwordHelper = passwordHelper;
			_smsService = smsService;
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

					//await _smsService.SendVerificationSms(user.Mobile, user.MobileActiveCode);

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
			
		}

		#endregion

		

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

        public async Task<ForgotPasswordResult> RecoverUserPassword(ForgotPasswordDTO forgotPassword)
        {
			try
			{
				var user = await _userRepository.GetQuery().SingleOrDefaultAsync(x => x.Mobile == forgotPassword.Mobile);
				if (user == null)
				{
					return ForgotPasswordResult.NotFound;
				};
				var newpassword = new Random().Next(1000000, 99999999).ToString();

				user.Password = _passwordHelper.EnCodePasswordMD5(newpassword);
				_userRepository.EditEntity(user);
				
				await _smsService.SendUserPassword(user.Mobile, newpassword);

				await _userRepository.SaveChanges();

				return ForgotPasswordResult.Success;
			}
			catch (Exception ex)
			{
				return ForgotPasswordResult.Error;
			}
			
        }

        public async Task<bool> ActivateMobile(ActivateMobileDTO activateMobile)
        {
			var user = await _userRepository.GetQuery().AsQueryable()
				.SingleOrDefaultAsync(s=> s.Mobile == activateMobile.Mobile);
			if (user != null)
			{
				if(user.MobileActiveCode == activateMobile.MobileActiveCode)
				{
					user.IsMobileActive = true;
					user.MobileActiveCode = new Random().Next(100000, 99999999).ToString();
					await _userRepository.SaveChanges();
					return true;
				}
			}
			return false;
        }

        #region change user Password

        public async Task<bool> ChangeUserPassword(ChangePasswordDTO changePass, long currentUserId)
        {
            var user = await _userRepository.GetEntityById(currentUserId);
            if (user != null)
            {
                var newPassword = _passwordHelper.EnCodePasswordMD5(changePass.NewPassword);
                if (newPassword != user.Password)
                {
                    user.Password = newPassword;
                    _userRepository.EditEntity(user);
                    await _userRepository.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public async Task<EditUserProfileDTO> GetProfileForEdit(long userId)
        {
            var user = await _userRepository.GetEntityById(userId);
            if (user == null) return null;

            return new EditUserProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.Avatar
            };
        }

        public async Task<EditUserProfileResult> EditUserProfile(EditUserProfileDTO profile, long userId, IFormFile avatarImage)
        {
            var user = await _userRepository.GetEntityById(userId);
            if (user == null) return EditUserProfileResult.NotFound;

            if (user.IsBlocked) return EditUserProfileResult.IsBlocked;
            if (!user.IsMobileActive) return EditUserProfileResult.IsNotActive;

            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;

            if (avatarImage != null && avatarImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(avatarImage.FileName);
                avatarImage.AddImageToServer(imageName, PathExtensions.UserAvatarOriginServer, 100, 100, PathExtensions.UserAvatarThumbServer, user.Avatar);
                user.Avatar = imageName;
            }

            _userRepository.EditEntity(user);
            await _userRepository.SaveChanges();

            return EditUserProfileResult.Success;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            await _userRepository.DisposeAsync();
        }

        #endregion
    }
}
