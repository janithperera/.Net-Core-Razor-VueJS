using AutoMapper;
using Empite_Dot_Net.Data.Database;
using Empite_Dot_Net.Data.Models;
using Empite_Dot_Net.Services.Interfaces;
using Empite_Dot_Net.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserServices userServices;
		private readonly IMapper mapper;

		public UsersController(IUserServices userServices, IMapper mapper)
		{
			this.mapper = mapper;
			this.userServices = userServices;
		}

 

		[HttpPost]
		public async Task<ActionResult> CreateUser([FromBody]CreateUserRequest request)
		{
			var user = AutoMapperUtility<CreateUserRequest, User>.GetMappedObject(request, mapper);
			await this.userServices.CreateUser(user);
			return Ok();
		}
	}
}
