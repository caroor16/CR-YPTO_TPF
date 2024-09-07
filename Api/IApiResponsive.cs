using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Api
{
	public interface IApiResponsive
	{
		dynamic Data { get; set; }
		void GetAPIResponseItem(string mUrl);
	}
}
