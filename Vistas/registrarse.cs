using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.Vistas
{
	public partial class registrarse : Form
	{

		fachada fachada = new fachada();
		public registrarse()
		{
			InitializeComponent();
		}

		private void btncancelar2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnregistrarse2_Click(object sender, EventArgs e)
		{
			if (ValidarFormulario())
			{			
					fachada.AgregarNuevoUsuario(textusuarioreg.Text, textnombre.Text, textapellido.Text, textcorreo.Text, textclavereg.Text);
					MostrarMensajeEnPanel(panel1, "Usuario registrado con éxito", Color.Green);
					textusuarioreg.Text = "";
					textnombre.Text = "";
					textapellido.Text = "";
					textcorreo.Text = "";
					textclavereg.Text = "";
			}
		}


		// Validar que el formulario tenga datos válidos
		private bool ValidarFormulario()
		{
			// Verificar si el usuario ya existe
			if (fachada.validarUsuario(textusuarioreg.Text))
			{
				MostrarMensajeEnPanel(panel1, "El usuario ya existe. Por favor, elige otro.", Color.Red);
				return false;
			}
			else if (textusuarioreg.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar un usuario", Color.Red);
				return false;
			}
			else if (textclavereg.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar una contraseña", Color.Red);
				return false;
			}
			else if (textnombre.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar un nombre", Color.Red);
				return false;
			}
			else if (textapellido.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar un apellido", Color.Red);
				return false;
			}
			else if (textcorreo.Text.Length == 0)
			{
				MostrarMensajeEnPanel(panel1, "Debe ingresar un correo", Color.Red);
				return false;
			}

			// Validar que el nombre de usuario solo tenga letras
			else if (!Regex.IsMatch(textusuarioreg.Text, @"^[a-zA-Z]+$"))
			{
				MostrarMensajeEnPanel(panel1, "El nombre de usuario solo puede contener letras.", Color.Red);
				return false;
			}
			// Validar el correo electrónico
			else if (!Regex.IsMatch(textcorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
			{
				MostrarMensajeEnPanel(panel1, "Por favor, ingrese un correo electrónico válido.", Color.Red);
				return false;
			}
			// Validar que la clave tenga más de 6 caracteres
			else if (textclavereg.Text.Length < 6)
			{
				MostrarMensajeEnPanel(panel1, "La clave debe tener al menos 6 caracteres.", Color.Red);
				return false;
			}

			return true;
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
