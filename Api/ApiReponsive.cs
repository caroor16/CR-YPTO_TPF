using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Microsoft.Extensions.Logging;


namespace CR_YPTO_TPF.Api
{
	public class ApiReponsive : IApiResponsive
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public dynamic data;
		public dynamic Data
		{
			get { return this.data; }
			set { this.data = value; }
		}
		public ApiReponsive()
		{;
		}
		public void GetAPIResponseItem(string mUrl)
		{
			try
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
			catch (WebException ex)
			{
				log.Error("Error: {0} " + ex.Message);
			}
			catch (Exception ex)
			{
				log.Error("Error: {0} " + ex.Message);
				MessageBox.Show("Cargando...");
			}
		}
	}
}

