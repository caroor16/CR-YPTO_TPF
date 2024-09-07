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

namespace CR_YPTO_TPF.DAL.framework
{
    public class UsCryptoRepository : Repository<AppDbContext, usuariocrypto>, IUsCryptoRepository
    {
        public UsCryptoRepository(AppDbContext context) : base(context)
        { }

        // Método para agregar una cripto favorita del usuario a la base de datos
        public void favoritosUs(usuariocrypto nuevoFavorito)
        {
            iDbContext.Set<usuariocrypto>().Add(nuevoFavorito);  // Agrega el favorito
            iDbContext.SaveChanges();
        }
    }
}
