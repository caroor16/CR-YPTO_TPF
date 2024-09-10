using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CR_YPTO_TPF.Domain
{
	public class usuariocrypto
	{
		//relación entre usuario y sus cryptos favs en la base de datos

		[ForeignKey("usuario")] //clave foránea que se mapea explícitamente
		public string idUsuario { get; set; }
		public string idCrypto { get; set; }

		// Relación inversa con Usuario
		public usuario usuario { get; set; }


		public usuariocrypto(string idUsuario, string idCrypto)
		{
			this.idUsuario = idUsuario;
			this.idCrypto = idCrypto;
		}
	}

	
}
