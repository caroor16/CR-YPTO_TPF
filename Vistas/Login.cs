using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using Microsoft.Data.SqlClient;
using ScottPlot.Renderable;

namespace CR_YPTO_TPF.Vistas
{
	public partial class Login : Form
	{
		
		fachada fachada = new fachada();
		log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");
		public static extern bool ReleaseCapture();
		public Login()
		{
			InitializeComponent();
			MostrarMensajeEnPanel(panel1, "", Color.Red);
		}

		// BOTONES 
		private void btningresar_Click(object sender, EventArgs e)
		{
			if (textusuario.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar un usuario.", Color.Red);
				return;
			}
			else if (textclave.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar una contraseña.", Color.Red);
				return;
			}
			else
			{
				try
				{
					// Obtener el usuario por el nombre de usuario ingresado
					var ousuario = fachada.GetUser(textusuario.Text);

					if (ousuario == null)
					{
						// Si el usuario no existe
						MostrarMensajeEnPanel(panel1, "El usuario no existe.", Color.Red);
					}
					else if (ousuario.clave != textclave.Text)
					{
						// Si la clave es incorrecta
						MostrarMensajeEnPanel(panel1, "La clave es incorrecta.", Color.Red);
					}
					else
					{
						// Si el usuario existe y la clave es correcta, permitir el acceso
						fachada.ActivarSesion(ousuario.idUsuario);
						MessageBox.Show("Login exitoso.");
						inicio form = new inicio();

						form.Show();
						this.Hide();

						form.FormClosing += frm_closing;
					}
				}
				catch (SqlException sqlEx) // Captura las excepciones de SQL
				{
					log.logger("Error en la conexión a la base de datos. Por favor, verifica la configuración.");
					MessageBox.Show("Error en la conexión a la base de datos. Por favor, verifica la configuración.");
				}
				catch (Exception ex)
				{
					// Manejar cualquier otro tipo de error
					log.logger("Error: " + ex.Message);
					MessageBox.Show("Error: " + ex.Message);
				}
			}
		}

		private void btnregistrarse_Click(object sender, EventArgs e)
		{
			MostrarMensajeEnPanel(panel1, "", Color.Red);
			// Crear una instancia del formulario registrarse y pasarle el repositorio de usuario
			registrarse form = new registrarse();

			// Mostrar el formulario de registro
			form.Show();
			// Ocultar el formulario actual
			this.Hide();

			// Manejar el evento FormClosing para volver a mostrar el formulario actual cuando se cierre el formulario de registro
			form.FormClosing += frm_closing;
		}
		private void btncancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void frm_closing(object sender, FormClosingEventArgs e)
		{
			textusuario.Text = "";
			textclave.Text = "";

			this.Show();
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

	}
}
