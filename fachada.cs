using System;
using Microsoft.Extensions.Logging;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.DAL.framework;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using CR_YPTO_TPF.Api;
using System.Net;
using System.Text;
using CR_YPTO_TPF.Modelo;
using CR_YPTO_TPF.Api.excepciones;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic.Logging;
using System.Net.Http;


namespace CR_YPTO_TPF
{
	public class fachada
	{
		//CryptoService interaccionCrypto = new CryptoService();

		log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");
		// ######################### MÉTODOS BÁSICOS DEL USUARIO #####################
		// Obtener el usuario actual
		
		

		public usuario GetUsuarioActual()
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			return repoUsuario.GetUsuarioActual();
		}

		// Obtener un usuario por su ID
		public usuario GetUser(string pidUsuario)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			return repoUsuario.Get(pidUsuario);
		}

		// Agregar un nuevo usuario
		public void AgregarNuevoUsuario(string idUsuario, string nombre, string apellido, string correo, string clave)
		{
			using (IUnitOfWork bUoW = new UnitOfWork(new AppDbContext()))
			{
				usuario ousuario = new usuario(idUsuario, nombre, apellido, correo, clave, 0, false);
				bUoW.UsuarioRepository.Add(ousuario);
				bUoW.Complete();
			}
		}

		// Validar si un usuario existe
		public bool validarUsuario(string idUsuario)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var buscado = repoUsuario.Get(idUsuario);
			if (buscado is null) { return false; }
			else return true;
		}

		// SESION DEL USUARIO:
		public static void ActivarSesion(string pidUsuario)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objUsuario = repoUsuario.Get(pidUsuario);
			objUsuario.activo = true;
			context.SaveChanges();
		}

		public static void DesactivarSesion()
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objUsuarios = repoUsuario.GetAll();
			foreach (var usuario in objUsuarios)
			{
				if (usuario.activo)
				{
					usuario.activo = false;
					MessageBox.Show("Sesión finalizada");

				}
			}
			context.SaveChanges();
		}

		// ############################# INICIO ########################

		//			VENTANA USUARIO  (modificar datos)  
		public void cambiarNombre(string nombre)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objUsuario = repoUsuario.GetUsuarioActual();
			objUsuario.nombre = nombre;
			context.SaveChanges();
		}

		public void cambiarApellido(string apellido)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objetoUsuario = repoUsuario.GetUsuarioActual();
			objetoUsuario.apellido = apellido;
			context.SaveChanges();
		}

		public void cambiarClave(string clave)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context); ;
			var objetoUsuario = repoUsuario.GetUsuarioActual();
			objetoUsuario.clave = clave;
			context.SaveChanges();
		}

		public void cambiarCorreo(string correo)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objetoUsuario = repoUsuario.GetUsuarioActual();
			objetoUsuario.correo = correo;
			context.SaveChanges();
		}

		public void cambiarUmbral(double umbral)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var objetoUsuario = repoUsuario.GetUsuarioActual();
			objetoUsuario.umbral = umbral;
			context.SaveChanges();

		}


		//		###########	VENTANA AVISOS   (notificaciones por correo y en pantalla)  



		//			###########  VENTANA FAVORITOS  (cryptos agregadas a favoritos - se puede agregar o eliminar selección)  

	
		public void AgregarCryptoFav(string idUsuario, string idCrypto)
		{
			using (IUnitOfWork bUoW = new UnitOfWork(new AppDbContext()))
			{
				// Verificamos si el usuario existe en la base de datos
				var usuario = bUoW.UsuarioRepository.Get(idUsuario);
				
				// Creamos el objeto `usuariocrypto` para asociar el usuario con la cripto favorita
				var nuevoFavorito = new usuariocrypto(idUsuario, idCrypto);

				// Agregamos la cripto a la lista de favoritas del usuario
				usuario.CriptomonedasFavoritas.Add(nuevoFavorito);

				// Guardamos los cambios en la base de datos
				bUoW.Complete();
			}
		}

		public void EliminarCryptoFav(string idUsuario, string idCrypto)
		{
			using (IUnitOfWork bUoW = new UnitOfWork(new AppDbContext()))
			{
				// Usamos el repositorio para eliminar el favorito
				var usCryptoRepository = new UsCryptoRepository(new AppDbContext());
				usCryptoRepository.EliminarFavorito(idUsuario, idCrypto);
				bUoW.Complete();

			}
		}

		public List<usuariocrypto> ObtenerListaFavoritas()
		{
			usuario user = GetUsuarioActual();
			AppDbContext context = new AppDbContext();
			UsCryptoRepository repoUsCr = new UsCryptoRepository(context);
			return repoUsCr.GetCriptosFav(user.idUsuario);
		}

		// Verificar si la cripto ya está en los favoritos
		public bool ExisteCripto(string criptoId)
		{
			// Obtener todas las criptomonedas favoritas del usuario
			var criptosFavoritas = ObtenerListaFavoritas();

			// Comprobar si la cripto ingresada ya está en la lista de favoritas
			return criptosFavoritas.Any(uc => uc.idCrypto == criptoId);
		}

		public List<cryptoDTO> CompararListaFavoritas(usuario usuario)
		{
			try
			{
				List<usuariocrypto> listaFavoritos = ObtenerListaFavoritas();

				//Verificamos que el usuario tenga criptos favoritas
				if (listaFavoritos == null || !listaFavoritos.Any())
				{
					return new List<cryptoDTO>(); // Si no tiene favoritas, devolvemos una lista vacía
				}

				// Convertimos la lista de usuariocrypto a una lista de IDs de criptomonedas (string)
				List<string> listaIdsCriptos = listaFavoritos
					.Select(uc => uc.idCrypto)
					.ToList();

				//Interactuamos con la API para obtener los detalles de las criptomonedas favoritas
				CryptoService interaccionCrypto = new CryptoService();
				var listaCryptos = interaccionCrypto.GetFavCryptos(listaIdsCriptos);

				return listaCryptos;
			}
			catch (WebException ex)
			{
				log.logger("Error: {0} " + ex.Message);
				DesactivarSesion();
				throw new ExcepcionesApi("Error: {0} " + ex.Message);
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error: {0} " + ex.Message);
				log.logger("Error: {0} " + ex.Message);
				DesactivarSesion();
				throw new ExcepcionesApi("Error de conexión con el servicio, intente más tarde"); 
			}
		}
		// interactúa con el servicio de criptos y retorna el historial
		public List<cryptohistoria> ObtenerHistorialCripto(string idCrypto)
		{
			usuario user = GetUsuarioActual();
			CryptoService cryptoService = new CryptoService();
			return cryptoService.GetHistorial(user.idUsuario, idCrypto);
		}
		

		//			VENTANA CRYPTO  (ver todas las criptos y/o una en especial)  

		//todas las criptomonedas
		public List<cryptoDTO> GetCryptosTodas()
		{
			try
			{
				CryptoService interaccionCrypto = new CryptoService();
				return interaccionCrypto.GetAllCryptos();
			}
			catch (WebException ex)
			{
				log.logger("Error: {0} " + ex.Message);
				DesactivarSesion();
				throw new ExcepcionesApi("Error: {0} " + ex.Message);
			}
			catch (Exception ex)
			{
				log.logger("Error: {0} " + ex.Message);
				//MessageBox.Show("Error: {0} " + ex.Message);
				DesactivarSesion();
				throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
			}

		}


	}
}
