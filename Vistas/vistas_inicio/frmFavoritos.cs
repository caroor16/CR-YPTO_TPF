using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Globalization;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmFavoritos : Form
	{
		fachada fachada = new fachada();


		NumberFormatInfo provider = new NumberFormatInfo();
		public frmFavoritos()
		{
			InitializeComponent();
			
		}

		//botones

		private void btnCryptoFav_Click(object sender, EventArgs e)
		{

			string criptoId = textidCryptoFav.Text.ToLower();

			if (criptoId.Length == 0)
			{
				fachada.MostrarMensajeEnPanel(panel1, "Debe ingresar el id de una crypto", Color.Black);
				return;
			}

			//verifica si el id ingresado es de una cripto
			var historial = fachada.GetHistorial(criptoId);

			if (historial.Count() == 0)
			{
				fachada.MostrarMensajeEnPanel(panel1, "La crypto ingresada no se encuentra", Color.Red);
				return;
			}

			//obtenemos el usuario
			usuario objetoUsuario = fachada.GetUsuarioActual();

			//ya está como favorito?
			if (!objetoUsuario.ExisteCripto(criptoId)) //si no está en favs
			{
				try
				{
					
					fachada.AgregarCryptoFav(objetoUsuario.idUsuario, criptoId);  //la agrega a favoritos
					fachada.MostrarMensajeEnPanel(panel1, "La crypto fue agregada a favoritos", Color.Green);
					////Grafico
					//formsPlotFav.Plot.Clear(); // Limpia el gráfico antes de agregar nuevos datos
					
					////actualizar gráfico
					//formsPlotFav.Plot.XTicks();
					//formsPlotFav.Refresh();

					//formsPlotFav.Plot.AddBarSeries();
					//formsPlotFav.Plot.SetAxisLimitsY(0, 5000);
					//formsPlotFav.Plot.XLabel("Criptomonedas favoritas");
					//formsPlotFav.Plot.YLabel("Precio en USD");
					//formsPlotFav.Refresh();
				}
				catch (Exception ex)
				{
					fachada.MostrarMensajeEnPanel(panel1, $"Error al agregar la cripto: {ex.Message}", Color.Red);
				}
			}
			else
			{
				fachada.MostrarMensajeEnPanel(panel1, "La crypto ya está entre las favoritas", Color.Black);
			}
		}
		

		

		private void btnElimCryptoFav_Click(object sender, EventArgs e)
		{

		}

		
	}
}
