using Empite_Dot_Net.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Services.Interfaces
{
	public interface IUserServices
	{
		/// <summary>
		/// Gets all users.
		/// </summary>
		/// <returns></returns>
		Task<List<User>> GetAllUsers();

		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <returns></returns>
		Task<User> GetUser(string email);

		/// <summary>
		/// Creates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		Task CreateUser(User user);
	}
}
