using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.Vistas;
using CR_YPTO_TPF.Api.excepciones;

namespace CR_YPTO_TPF.DAL.framework
{
	public class UsuarioRepository : Repository<AppDbContext, usuario>, IUsuarioRepository
	{
		//private readonly AppDbContext _context;

		public UsuarioRepository(AppDbContext context) : base(context)
		{

		}

		// Implementación de Get


		public usuario GetUsuarioActual()
		{

			var arrayUsuarios = iDbContext.Set<usuario>();
			usuario usuarioActual = null;
			foreach (var usuario in arrayUsuarios)
			{
				if (usuario.activo)
				{
					usuarioActual = usuario;
				}
			}
			if (usuarioActual == null)
			{
				MessageBox.Show("El usuario no está logueado");
				throw new ExcepcionesApi("El usuario no se pudo encontrar porque no está logueado");
			}
			else
			{
				return usuarioActual;
			}

		}


	}
}