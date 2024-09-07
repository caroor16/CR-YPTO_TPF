using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.Domain;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.Vistas;
using CR_YPTO_TPF.Vistas.vistas_inicio;

namespace CR_YPTO_TPF.Vistas
{
	public partial class inicio : Form
	{
		fachada fachada = new fachada();
		//usuario ousuario = fachada.GetUsuarioActual();

		private static IconMenuItem MenuActivo = null;
		private static Form FormularioActivo = null;

		public inicio()
		{
			InitializeComponent();
			menuModoUso();
		}

		//recibe el menu que fue cliqueado y el formulario q desea mostrar 
		private void AbrirFormulario(IconMenuItem menu, Form formulario)
		{

			//para ponerle color cuando cliqueas 
			if (MenuActivo != null)
			{ //que hay un menu anterior
				MenuActivo.BackColor = Color.White; //si lo hay q quede de color blanco
			}
			menu.BackColor = Color.Silver; //que el que esté por marcar q cambie de color
			MenuActivo = menu;

			if (FormularioActivo != null)
			{
				FormularioActivo.Close();
			}

			FormularioActivo = formulario; //cambio de formulario
			formulario.TopLevel = false;
			formulario.FormBorderStyle = FormBorderStyle.None;
			formulario.Dock = DockStyle.Fill;

			contenedor.Controls.Add(formulario); //agregar el formulario
			formulario.Show(); // lo muestra

		}

		// TODOS LOS MENU
		private void menuUsuario_Click(object sender, EventArgs e)
		{
			AbrirFormulario((IconMenuItem)sender, new frmUsuario());
		}

		private void menuAvisos_Click(object sender, EventArgs e)
		{
			AbrirFormulario((IconMenuItem)sender, new frmAvisos());
		}

		private void menuFavoritos_Click(object sender, EventArgs e)
		{
			AbrirFormulario((IconMenuItem)sender, new frmFavoritos());
		}

		private void menuCrypto_Click(object sender, EventArgs e)
		{
			AbrirFormulario((IconMenuItem)sender, new frmCrypto());
		}

		private void cerrarS_Click(object sender, EventArgs e)
		{
			fachada.DesactivarSesion();
			this.Close();
		}


		private void menuModoUso()
		{
			// Crear una instancia del formulario frmModoUso
			frmModoUso formulario = new frmModoUso();

			// Configurar el formulario
			formulario.TopLevel = false;
			formulario.FormBorderStyle = FormBorderStyle.None;
			formulario.Dock = DockStyle.Fill;

			// Agregar el formulario al contenedor
			contenedor.Controls.Add(formulario);

			// Mostrar el formulario
			formulario.Show();
			FormularioActivo = formulario;

		}

		//extras
		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{ }

		private void inicio_Load(object sender, EventArgs e)
		{ }

		private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{ }

		
	}
}
