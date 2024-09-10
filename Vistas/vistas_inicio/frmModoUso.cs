using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Windows.Forms;
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
			string idUser = usuario.idUsuario;

			//etiqueta para mostrar el usuario
			System.Windows.Forms.Label labelID = new System.Windows.Forms.Label();
			labelID.Text = idUser;
			labelID.ForeColor = System.Drawing.Color.White;
			labelID.Font = new Font("Arial", 13.8f);

			// Agrega la etiqueta al panel
			panelID.Controls.Add(labelID);
		}
	}
}
