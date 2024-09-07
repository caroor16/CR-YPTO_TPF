using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CR_YPTO_TPF.Domain
{
	public partial class alerta
	{
		public string idUsuario { get; set; } 
		public string idCrypto { get; set; }
		public double umbralAlerta { get; set; }
		public DateTime fecha { get; set; }
	}
}
