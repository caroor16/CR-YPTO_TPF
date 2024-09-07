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
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmUsuario : Form
	{
		fachada fachada = new fachada();
		
		public frmUsuario()
		{
			InitializeComponent();
			datosActuales();

		}

		private void btnGuardarCambios_Click(object sender, EventArgs e)
		{
			bool datosModificados = false;

			
			if (textNombreNuevo.Text.Length > 0)
			{
				fachada.cambiarNombre(textNombreNuevo.Text);
				datosModificados = true;
				datosActuales();
			}

			if (textApellidoNuevo.Text.Length > 0)
			{
				fachada.cambiarApellido(textApellidoNuevo.Text);
				datosModificados = true;
				datosActuales();
			}

			if (textCorreoNuevo.Text.Length > 0)
			{
				if (!Regex.IsMatch(textCorreoNuevo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
				{
					fachada.MostrarMensajeEnPanel(panel1, "Por favor, ingrese un correo electrónico válido.", Color.Red);
					return;
				}
				else
				{
					fachada.cambiarCorreo(textCorreoNuevo.Text);
					datosModificados = true;
					datosActuales();
				}
			}

			if (textClaveNuevo.Text.Length > 0)
			{
				if (textClaveNuevo.Text.Length < 6)
				{
					fachada.MostrarMensajeEnPanel(panel1, "La clave debe tener al menos 6 caracteres.", Color.Red);
					return;
				}
				else
				{
					fachada.cambiarClave(textClaveNuevo.Text);
					datosModificados = true;
					datosActuales();
				}
			}

			if (textUmbralNuevo.Text.Length > 0)
			{
				if (!double.TryParse(textUmbralNuevo.Text, out double umbral))
				{
					fachada.MostrarMensajeEnPanel(panel1, "El umbral debe ser un número.", Color.Red);
					return;
				}
				else
				{
					fachada.cambiarUmbral(double.Parse(textUmbralNuevo.Text));
					datosModificados = true;
					datosActuales();
				}

			}

			if (datosModificados)
			{
				fachada.MostrarMensajeEnPanel(panel1, "", Color.White); //eliminar los mensajes extras
				//datosActuales();
				MessageBox.Show("Datos modificados con éxito.");
			}
			else
			{
				fachada.MostrarMensajeEnPanel(panel1, "Debe modificar al menos un dato para guardar cambios.", Color.Red);
			}

		}

		//Datos
		public void datosActuales()
		{
			var usuario = fachada.GetUsuarioActual();
			
			// Usuario
			fachada.MostrarMensajeEnPanel(panelId, usuario.idUsuario, Color.Gainsboro);

			// Nombre
			fachada.MostrarMensajeEnPanel(panelN, usuario.nombre, Color.White);

			// Apellido
			fachada.MostrarMensajeEnPanel(panelA, usuario.apellido, Color.White);

			// Umbral
			fachada.MostrarMensajeEnPanel(panelU, usuario.umbral.ToString(), Color.White);

			//correo
			fachada.MostrarMensajeEnPanel(panelC, usuario.correo, Color.White);

			// Clave
			string clave = new string('*', usuario.clave.Length);
			fachada.MostrarMensajeEnPanel(panelCl, clave, Color.White);
		}


	}
}
