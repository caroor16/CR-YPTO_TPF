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

namespace CR_YPTO_TPF
{
	public class fachada
	{
		//CryptoService interaccionCrypto = new CryptoService();

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
				usuario ousuario = new usuario(idUsuario, nombre, apellido, correo, clave, 0, true);
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

		//historial de las criptomonedas
		public List<cryptohistoria> GetHistorial(string cripto)
		{
			try
			{
				var user = GetUsuarioActual();
				// Interacción con la API
				CryptoService interaccionApi = new CryptoService();  
				var historial = interaccionApi.Get6MesesHistorial(user.idUsuario, cripto);
				return historial;
			}
			catch (WebException ex)
			{
				if (ex.Response is null)
				{

					throw new ExcepcionesApi("Error con el servicio de criptomonedas");
				}
				else
				{
					WebResponse mErrorResponse = ex.Response;
					using (Stream mResponseStream = mErrorResponse.GetResponseStream())
					{
						StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
						//String mErrorText = mReader.ReadToEnd();
						List<cryptohistoria> empty = new List<cryptohistoria>();
						return empty;

					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: {0} " + ex.Message);
				throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
			}
		}

		

		//			VENTANA CRYPTO  (ver todas las criptos ¿y/o una en especial?)  

		//todas las criptomonedas
		public List<crypto> GetCryptosTodas()
		{
			try
			{
				CryptoService interaccionCrypto = new CryptoService();
				return interaccionCrypto.GetAllCryptos();
			}
			catch (WebException ex)
			{
				return ManejarExcepcionApi(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: {0} " + ex.Message);
				throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
			}

		}


		//								 ########### EXTRA ###########	

		///panel de mensajes
		public void MostrarMensajeEnPanel(Panel panel, string mensaje, Color color)
		{
			panel.Controls.Clear();
			// Crea un Label para mostrar el mensaje
			Label lblMensaje = new Label();

			// Centrar el Label dentro del Panel
			lblMensaje.Location = new Point(10, 10);

			// Configura las propiedades del Label
			lblMensaje.Text = mensaje;
			lblMensaje.AutoSize = true;
			lblMensaje.ForeColor = color;
			lblMensaje.Font = new Font("Arial", 9, FontStyle.Bold);


			panel.Controls.Add(lblMensaje);
		}

		//Errores API
		private List<crypto> ManejarExcepcionApi(WebException ex)
		{
			if (ex.Response == null)
			{
				MessageBox.Show("Error: no hubo respuesta del servicio");
				throw new ExcepcionesApi("Se ha producido un error con el servicio de datos de Criptomonedas, intente más tarde");
			}

			using (Stream mResponseStream = ex.Response.GetResponseStream())
			{
				StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
				string mErrorText = mReader.ReadToEnd();
				MessageBox.Show("Error de API: " + mErrorText);
				return new List<crypto>(); // Retorna lista vacía si hay error
			}
		}

	}
}
