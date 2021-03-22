using Empite_Dot_Net.Data;
using Empite_Dot_Net.Data.Database;
using Empite_Dot_Net.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Services
{
	public class UserServices : IUserServices
	{
		private readonly TestDbContext testDbContext;

		public UserServices()
		{
			testDbContext = new TestDbContext();
		}
		 
		/// <summary>
		/// Gets all users.
		/// </summary>
		/// <returns></returns>
		public async Task<List<User>> GetAllUsers()
		{
			var users = await testDbContext.Users.FromSqlRaw(Constants.GetAllUsers).ToListAsync();
			return users;
		}

		public async Task<User> GetUser(string email)
		{
			var parameters = new SqlParameter[]
			{
				new SqlParameter("@email", email)
			};
			var user = await testDbContext.Users.FromSqlRaw(Constants.GetUserByEmail).FirstOrDefaultAsync();
			return user;
		}

		/// <summary>
		/// Creates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		public async Task CreateUser(User user)
		{
			var parameters = new SqlParameter[] 
			{ 
				new SqlParameter("@type", user.Type), 
				new SqlParameter("@firstname", user.FirstName),
				new SqlParameter("@lastname", user.LastName),
				new SqlParameter("@password", user.Password),
				new SqlParameter("@email", user.Email)
			};
			await testDbContext.Database.ExecuteSqlRawAsync(Constants.AddUser, parameters);
		}
	}
}
