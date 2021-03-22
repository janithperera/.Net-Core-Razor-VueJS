using Empite_Dot_Net.Data.Database;
using Empite_Dot_Net.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empite_Dot_Net.App.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		

		[HttpGet("[action]")]
		public async Task<ActionResult> GetUsers()
		{
			this.userServices.CreateUser(new User
			{
				Email = "jccandro@gmail.com",
				FirstName = "Janith",
				LastName = "Perers",
				IsActive = true,
				Password = "jc123",
				Type = "Admin"
			});

			var users = await this.userServices.GetAllUsers();
			return Ok(users);
		}
	}
}
