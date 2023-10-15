using DemoShop.Application.Interface;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
	public class UserService : IUserService
	{
		private readonly IGenericRepository<User> _userRepository;

		public UserService(IGenericRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async ValueTask DisposeAsync()
		{
			await _userRepository.DisposeAsync();
		}
	}
}
