using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.Vistas;
using CR_YPTO_TPF.Api.excepciones;

namespace CR_YPTO_TPF.DAL.framework
{
    public class UsCryptoRepository : Repository<AppDbContext, usuariocrypto>, IUsCryptoRepository
    {
        public UsCryptoRepository(AppDbContext context) : base(context)
        { }

		
		//para obtener todas las criptos del usuario en la base de datos
		public List<usuariocrypto> GetCriptosFav(string idUsuario)
		{
			// Obtiene todas las criptomonedas favoritas del usuario con idUsuario
			return iDbContext.Set<usuariocrypto>()
							 .Where(uc => uc.idUsuario == idUsuario)
							 .ToList();
		}

		// Método para eliminar una cripto favorita del usuario de la base de datos
		public void EliminarFavorito(string idUsuario, string idCrypto)
		{
			var favorito = iDbContext.Set<usuariocrypto>()
				.FirstOrDefault(uc => uc.idUsuario == idUsuario && uc.idCrypto == idCrypto);

			if (favorito != null)
			{
				iDbContext.Set<usuariocrypto>().Remove(favorito);
				iDbContext.SaveChanges();
			}
		}


	}
}
