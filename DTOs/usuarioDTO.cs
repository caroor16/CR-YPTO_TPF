using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.DTOs
{
	public class UsuarioDTO
	{
		public string idUsuario { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public string correo { get; set; }
		public string clave { get; set; }
		public double umbral { get; set; }
		public bool activo { get; set; }

		// Criptomonedas favoritas en formato DTO
		public List<UsuariocryptoDTO> CriptomonedasFavoritas { get; set; }
	}


}

