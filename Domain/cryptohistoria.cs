using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Domain
{
	public class cryptohistoria
	{
		
		public int idcryptohistoria { get; set; }
		public string idUsuario { get; set; }
		public string idCrypto { get; set; }

		
		public string precio { get; set; }
		public DateTime fecha { get; set; }

		// Constructor parametrizado
		public cryptohistoria(string idUsuario, string idCrypto, string pPriceUSD, DateTime pTime)
		{
			this.idUsuario = idUsuario;
			this.idCrypto = idCrypto;
			this.precio = pPriceUSD;
			this.fecha = pTime;
		}

		public cryptohistoria() { }

		public string PriceUSD
		{
			get { return precio; }
			set { precio = value; }
		}

		public DateTime Time
		{
			get { return fecha; }
			set { fecha = value; }
		}
	}
}
