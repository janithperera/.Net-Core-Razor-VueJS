using AutoMapper;
using Empite_Dot_Net.Data.Database;
using Empite_Dot_Net.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Services
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<CreateUserRequest, User>().ReverseMap();
		}
	}
}
