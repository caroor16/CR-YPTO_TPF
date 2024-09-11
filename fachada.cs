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
using CR_YPTO_TPF.DTOs;
using CR_YPTO_TPF.Api.excepciones;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic.Logging;
using System.Net.Http;
using System.Globalization;
using System.Runtime.Caching;



namespace CR_YPTO_TPF
{
	public class fachada
	{

		//para ver si ya contamos con la información de las criptomonedas
		public ObjectCache _cache = MemoryCache.Default;
		private TimeSpan _cacheDuracion = TimeSpan.FromHours(12); // Definimos el tiempo de duración en el caché (12 horas)

		log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");
		
		// ######################### MÉTODOS BÁSICOS DEL USUARIO #####################
		// Obtener el usuario actual
		public usuarioDTO GetUsuarioActual()
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);

			var usuario = repoUsuario.GetUsuarioActual();

			// Mapear Usuario a UsuarioDTO
			return new usuarioDTO
			{
				idUsuario = usuario.idUsuario,
				nombre = usuario.nombre,
				apellido = usuario.apellido,
				correo = usuario.correo,
				clave = usuario.clave,
				umbral = usuario.umbral,
				activo = usuario.activo
			};
		}

		// Obtener un usuario por su ID
		public usuarioDTO GetUser(string pidUsuario)
		{
			AppDbContext context = new AppDbContext();
			UsuarioRepository repoUsuario = new UsuarioRepository(context);
			var usuario = repoUsuario.Get(pidUsuario);

			if (usuario == null)
			{
				//  no se encuentra el usuario
				return null; 
			}

			// Mapear Usuario a UsuarioDTO
			return new usuarioDTO
			{
				idUsuario = usuario.idUsuario,
				nombre = usuario.nombre,
				apellido = usuario.apellido,
				correo = usuario.correo,
				clave = usuario.clave,
				umbral = usuario.umbral,
				activo = usuario.activo
			};
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
		public List<(string criptoId, decimal cambio24hs)> GetAlertas()
		{
			usuarioDTO user = GetUsuarioActual(); // Obtener datos del usuario actual
			if (user == null) throw new InvalidOperationException("Usuario no encontrado.");

			List<usuariocryptoDTO> criptosFavoritas = ObtenerListaFavoritas(); // Obtener lista de criptos favoritas del usuario
			List<cryptoDTO> cryptsTodas = GetCryptosTodas(); // Obtener todas las criptos

			var criptosSuperanUmbral = new List<(string criptoId, decimal cambio24hs)>(); // Lista para criptos que superan el umbral

			// Iterar sobre las criptos favoritas del usuario
			foreach (var criptoFav in criptosFavoritas)
			{
				// Buscar la cripto favorita en la lista completa de criptos
				var criptoDTO = cryptsTodas.FirstOrDefault(c => c.Id == criptoFav.idCrypto);

				if (criptoDTO != null)
				{
					// Convertir el cambio porcentual a decimal y compara con el umbral
					decimal cambio24hs = Convert.ToDecimal(criptoDTO.ChangePercent24hs, CultureInfo.InvariantCulture);
					if (Math.Abs(cambio24hs) >= (decimal)user.umbral) // Convertir umbral a decimal para la comparación
					{
						// Agregar la cripto y el cambio a la lista si supera el umbral
						criptosSuperanUmbral.Add((criptoDTO.Id, cambio24hs));
					}
				}
			}

			return criptosSuperanUmbral; // Retornar la lista con las criptos que superan el umbral
		}



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

		public List<usuariocryptoDTO> ObtenerListaFavoritas()
		{
			usuarioDTO user = GetUsuarioActual();
			AppDbContext context = new AppDbContext();
			UsCryptoRepository repoUsCr = new UsCryptoRepository(context);

			// Obtener la lista de usuariocrypto
			var listaUsuarioCrypto = repoUsCr.GetCriptosFav(user.idUsuario);

			// Mapear la lista a UsuarioCryptoDTO
			return listaUsuarioCrypto.Select(uc => new usuariocryptoDTO
			{
				idUsuario = uc.idUsuario,
				idCrypto = uc.idCrypto
			}).ToList();
		}

		// Verificar si la cripto ya está en los favoritos
		public bool ExisteCripto(string criptoId)
		{
			// Obtener todas las criptomonedas favoritas del usuario
			var criptosFavoritas = ObtenerListaFavoritas();

			// Comprobar si la cripto ingresada ya está en la lista de favoritas
			return criptosFavoritas.Any(uc => uc.idCrypto == criptoId);
		}


		//compara entre todas las criptos (api) y las criptos favoritas del usuario (bdd)
		public List<cryptoDTO> CompararListaFavoritas(usuarioDTO usuario)
		{
			try
			{
				// Obtener la lista de favoritos del usuario desde la base de datos
				List<usuariocryptoDTO> listaFavoritos = ObtenerListaFavoritas();

				//Verificamos que el usuario tenga criptos favoritas
				if (listaFavoritos == null || !listaFavoritos.Any())
				{
					return new List<cryptoDTO>(); // Si no tiene favoritas, devolvemos una lista vacía
				}
				else
				{
					// Convertimos la lista de usuariocrypto a una lista de IDs de criptomonedas (string)
					List<string> listaIdsCriptos = listaFavoritos
						.Select(uc => uc.idCrypto)
						.ToList();

					// Interactuamos con la API para obtener los detalles de las criptomonedas favoritas
					CryptoService interaccionCrypto = new CryptoService();
					return interaccionCrypto.GetFavCryptos(listaIdsCriptos);
				}
				
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
				DesactivarSesion();
				MessageBox.Show("Error de conexión con el servicio, intente más tarde");
				throw new ExcepcionesApi("Error de conexión con el servicio"); 
			}
		}
		// interactúa con el servicio de criptos y retorna el historial
		public List<cryptohistoriaDTO> ObtenerHistorialCripto(string idCrypto)
		{
			string cacheKey = $"Historial_{idCrypto}";
			ObjectCache cache = MemoryCache.Default;

			// Verificamos si el historial ya está en caché
			if (cache.Contains(cacheKey))
			{
				var cachedHistorial = (List<cryptohistoria>)cache.Get(cacheKey);
				return cachedHistorial.Select(ch => new cryptohistoriaDTO
				{
					//idUsuario = ch.idUsuario, 
					idCrypto = ch.idCrypto,
					PriceUSD = ch.precio,
					Time = ch.fecha
				}).ToList();
			}
			else
			{
				// Si no está en caché, hacemos la solicitud a la API
				usuarioDTO user = GetUsuarioActual();
				CryptoService cryptoService = new CryptoService();
				var historial = cryptoService.Get6MesesHistorial(user.idUsuario, idCrypto);

				// Guardamos el historial en caché por 12 horas
				CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.Add(_cacheDuracion) };
				cache.Add(cacheKey, historial, policy);

				// Mapear la lista de cryptohistoria a CryptoHistoriaDTO
				return historial.Select(ch => new cryptohistoriaDTO
				{
					//idUsuario = ch.idUsuario,
					idCrypto = ch.idCrypto,
					PriceUSD = ch.precio,
					Time = ch.fecha
				}).ToList();
			}
			
		}
		

		//			VENTANA CRYPTO  (ver todas las criptos y/o una en especial)  

		//todas las criptomonedas
		public List<cryptoDTO> GetCryptosTodas()
		{
			// Método para obtener criptomonedas, ya sea desde el caché o la API

			string cacheKey = "AllCryptos"; // Clave única para las criptomonedas

			// Verificar si las criptomonedas ya están en el caché
			if (_cache.Contains(cacheKey))
			{
				// Si están en caché, las retornamos
				return (List<cryptoDTO>)_cache.Get(cacheKey);
			}
			else
			{
				// Si no están en caché, las obtenemos desde la API
					CryptoService interaccionCrypto = new CryptoService();
					var listaCryptos = interaccionCrypto.GetAllCryptos();

					// Guardar los datos en el caché por la duración definida
					_cache.Add(cacheKey, listaCryptos, DateTimeOffset.Now.Add(_cacheDuracion));

					return listaCryptos;
			}
		}
	}
}
