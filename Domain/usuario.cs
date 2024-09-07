using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CR_YPTO_TPF.DAL.framework;

namespace CR_YPTO_TPF.Domain
{
	public class usuario
	{
		public string idUsuario { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public string correo { get; set; }
		public string clave { get; set; }
		public double umbral { get; set; }
		public bool activo { get; set; }

		public usuario(string idUsuario, string nombre, string apellido, string correo, string clave, double umbral, bool activo)
		{
			this.idUsuario = idUsuario;
			this.nombre = nombre;
			this.apellido = apellido;
			this.correo = correo;
			this.clave = clave;
			this.umbral = umbral;
			this.activo = activo;
		}

		// Lista de criptomonedas favoritas
		public List<usuariocrypto> CriptomonedasFavoritas { get; set; } = new List<usuariocrypto>();

		// Verificar si la cripto ya está en los favoritos ##
		//se usa usuariocrypto para verificar si esa cripto ya está en la lista de favoritos del usuario
		public bool ExisteCripto(string cripto)
		{
			return CriptomonedasFavoritas.Any(uc => uc.idCrypto == cripto);
		}

		
	}
}
