using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmModoUso : Form
	{
		fachada fachada = new fachada();

		public frmModoUso()
		{
			InitializeComponent();
			usuarioActualVista();
		}

		private void frmModoUso_Load(object sender, EventArgs e) 
		{
			
		}

		public void usuarioActualVista()
		{
			var usuario = fachada.GetUsuarioActual();

			// Usuario
			//fachada.MostrarMensajeEnPanel(panel1, usuario.idUsuario, System.Drawing.Color.White);
		}

		//								 ########### EXTRA ###########	

		///panel de mensajes
		//public void MostrarMensajeEnPanel(Panel panel, string mensaje, Color color)
		//{
		//	panel.Controls.Clear();
		//	// Crea un Label para mostrar el mensaje
		//	Label lblMensaje = new Label();

		//	// Centrar el Label dentro del Panel
		//	lblMensaje.Location = new Point(10, 10);

		//	// Configura las propiedades del Label
		//	lblMensaje.Text = mensaje;
		//	lblMensaje.AutoSize = true;
		//	lblMensaje.ForeColor = color;
		//	lblMensaje.Font = new Font("Arial", 9, FontStyle.Bold);


		//	panel.Controls.Add(lblMensaje);
		//}
	}
}
