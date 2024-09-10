using CR_YPTO_TPF.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CR_YPTO_TPF.Domain;
using System.Text.Json;
using CR_YPTO_TPF.Vistas;
using CR_YPTO_TPF.Api.excepciones;
using System.Net;
using System.Text;

namespace CR_YPTO_TPF.Api
{
	public class CryptoService : ICryptoService
	{
		log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");

		public static string assetsUrl = "https://api.coincap.io/v2/assets";
		public static string history = "https://api.coincap.io/v2/assets/{0}/history?interval=d1";
		public dynamic dataAccessor;


		public dynamic DataAccessor
		{
			get { return this.dataAccessor; }
			set { this.dataAccessor = value; }
		}

		public CryptoService()
		{
			var response = new ApiReponsive();
			response.GetAPIResponseItem(assetsUrl);
			DataAccessor = response.data;
		}

		public List<cryptoDTO> GetAllCryptos()
		{
			var lista = new List<cryptoDTO>();
			foreach (var bResponseItem in dataAccessor.data)
			{
				var objetoDTO = new cryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
				lista.Add(objetoDTO);
			}
			return lista;


		}

		public List<cryptoDTO> GetFavCryptos(List<String> pLista)
		{
			var lista = new List<cryptoDTO>();
			foreach (var elemento in pLista)
			{
				foreach (var bResponseItem in dataAccessor.data)
				{
					if (elemento == bResponseItem.id.ToString())
					{
						var objeto = new cryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
						lista.Add(objeto);
					}
				}
			}
			return lista;

		}

		//historial de 6 meses con los precios de las criptos
		public List<cryptohistoria> Get6MesesHistorial(string idUsuario, string idCrypto)
		{
			var historial = new List<cryptohistoria>();
			var fechaActual = DateTime.Now;
			var seisMesesAtras = ((DateTimeOffset)(fechaActual.AddMonths(-6).ToUniversalTime())).ToUnixTimeMilliseconds(); //calcula la fecha
			var conexionHistory = new ApiReponsive(); //se comunica con la api
			
			string historyUrl = String.Format(history, idCrypto);  // idCrypto se usa en la URL de la APIhttps://chatgpt.com/c/66dbf52e-8830-800e-8559-ee21c77d1e2f
			conexionHistory.GetAPIResponseItem(historyUrl); //obtener respuesta de la api
			DataAccessor = conexionHistory.Data; //asignamos el resultado

			if (DataAccessor != null)
			{
				foreach (var bResponseItem in DataAccessor.data)
				{
					if ((bResponseItem.time) >= seisMesesAtras) //filtro por fecha
					{
						string precio = bResponseItem.priceUsd;

						long tiempo = bResponseItem.time;
						DateTimeOffset offset = DateTimeOffset.FromUnixTimeMilliseconds(tiempo);
						DateTime convertido = offset.UtcDateTime.ToLocalTime();

						var elementoHistorial = new cryptohistoria(idUsuario, idCrypto, precio, convertido);
						historial.Add(elementoHistorial);
					}
				}
				return historial;
			}
			else
			{
				log.logger("La respuesta de la api es nula");
				return historial; //devuelve una lista vacía
			}
		}


		//historial de las criptomonedas
		public List<cryptohistoria> GetHistorial(string idUsuario, string cripto)
		{
			try
			{
				// Interacción con la API
				CryptoService interaccionApi = new CryptoService();
				var historial = interaccionApi.Get6MesesHistorial(idUsuario, cripto);
				return historial;
			}
			catch (WebException ex)
			{
				if (ex.Response is null)
				{
					log.logger("Error: {0} " + ex.Message);
					MessageBox.Show("Error con el servicio de criptomonedas");
					
					throw new ExcepcionesApi("Error con el servicio de criptomonedas");
				}
				else
				{
					WebResponse mErrorResponse = ex.Response;
					using (Stream mResponseStream = mErrorResponse.GetResponseStream())
					{
						StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
						//String mErrorText = mReader.ReadToEnd();
						List<cryptohistoria> empty = new List<cryptohistoria>();
						return empty;

					}
				}
			}
			catch (Exception ex)
			{
				log.logger("Error: {0} " + ex.Message);
				MessageBox.Show("Ha ocurrido un error. Por favor, intente nuevamente más tarde.");
				return new List<cryptohistoria>();
			}
		}
	}


}
