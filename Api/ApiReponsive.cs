using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace CR_YPTO_TPF.Api
{
	public class ApiReponsive : IApiResponsive
	{
		public dynamic data;
		public dynamic Data
		{
			get { return this.data; }
			set { this.data = value; }
		}
		public ApiReponsive()
		{

		}
		public void GetAPIResponseItem(string mUrl)
		{

			// Se crea el request http
			HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);
			
			// Se ejecuta la consulta
			WebResponse mResponse = mRequest.GetResponse();
			// Se obtiene los datos de respuesta
			Stream responseStream = mResponse.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

			// Se parsea la respuesta y se serializa a JSON a un objeto dynamic
			dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());
			//return mResponseJSON;
			Data = mResponseJSON;
			
			
		}
	}
}

