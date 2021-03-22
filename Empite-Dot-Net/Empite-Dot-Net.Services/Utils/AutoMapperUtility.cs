using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Services.Utils
{
	public static class AutoMapperUtility<S, T>
	{
		public static T GetMappedObject(S source, IMapper mapper)
		{
			return mapper.Map<T>(source);
		}
	}
}
