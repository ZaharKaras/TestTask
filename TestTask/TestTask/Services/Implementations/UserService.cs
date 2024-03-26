using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
	public class UserService : IUserService
	{
		private DbSet<User> _users;

		public UserService(ApplicationDbContext context)
		{
			_users = context.Users;
		}
		public async Task<User> GetUser()
		{
			return await _users.OrderByDescending(u => u.Orders.Count)
				.FirstOrDefaultAsync();
		}

		public async Task<List<User>> GetUsers()
		{
			return await _users.Where(u => u.Status == UserStatus.Inactive)
				.ToListAsync();
		}
	}
}
