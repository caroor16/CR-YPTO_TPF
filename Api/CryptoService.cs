﻿using CR_YPTO_TPF.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CR_YPTO_TPF.Domain;
using System.Text.Json;
using CR_YPTO_TPF.Vistas;

namespace CR_YPTO_TPF.Api
{
	public class CryptoService : ICryptoService
	{

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

		public List<crypto> GetAllCryptos()
		{
			var lista = new List<crypto>();
			foreach (var bResponseItem in dataAccessor.data)
			{
				var objetoDTO = new crypto(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
				lista.Add(objetoDTO);
			}
			return lista;


		}

		public List<crypto> GetFavCryptos(List<String> pLista)
		{
			var lista = new List<crypto>();
			foreach (var elemento in pLista)
			{
				foreach (var bResponseItem in dataAccessor.data)
				{
					if (elemento == bResponseItem.id.ToString())
					{
						var objeto = new crypto(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
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
			
			string historyUrl = String.Format(history, idCrypto);  // idCrypto se usa en la URL de la API
			conexionHistory.GetAPIResponseItem(historyUrl); //obtener respuesta de la api
			DataAccessor = conexionHistory.Data; //asignamos el resultado

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

	}


}
