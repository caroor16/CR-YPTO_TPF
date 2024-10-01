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
using CR_YPTO_TPF.Api;
using CR_YPTO_TPF.DTOs;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmFavoritos : Form
	{
		Fachada fachada = new Fachada();
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		NumberFormatInfo provider = new NumberFormatInfo();  //para dar formato a los números
		public frmFavoritos()
		{
			InitializeComponent();
			mostrarDataFavoritas();
		}

		// #### BOTONES ####

		private void btnCryptoFav_Click(object sender, EventArgs e)
		{
			MostrarMensajeEnPanel(panel1, "", Color.Red);
			string criptoId = textidCryptoFav.Text.ToLower();

			if (criptoId.Length == 0)
			{
				//Log.logger("Debe ingresar el id de una crypto");
				MostrarMensajeEnPanel(panel1, "Debe ingresar el id de una crypto", Color.Black);
				return;
			}


			//verifica si el id ingresado es de una cripto
			var historial = fachada.ObtenerHistorialCripto(criptoId);

			if (historial.Count() == 0)
			{
				MostrarMensajeEnPanel(panel1, "La crypto ingresada no se encuentra", Color.Red);
				return;
			}

			//obtenemos el usuario
			UsuarioDTO objetoUsuario = fachada.GetUsuarioActual();

			//ya está como favorito?
			if (!fachada.ExisteCripto(criptoId)) //si no está en favs
			{
				try
				{
					fachada.AgregarCryptoFav(objetoUsuario.idUsuario, criptoId);  //la agrega a favoritos
					MostrarMensajeEnPanel(panel1, "La crypto fue agregada a favoritos", Color.Green);
					

					//Grafico
					formsPlotFav.Plot.Clear(); // Limpia el gráfico antes de agregar nuevos datos
					mostrarDataFavoritas();
					
				}
				catch (Exception ex)
				{
					log.Error($"Error al agregar la cripto: {ex.Message}");
					MostrarMensajeEnPanel(panel1, $"Error al agregar la cripto: {ex.Message}", Color.Red);
				}
			}
			else
			{
				MostrarMensajeEnPanel(panel1, "La crypto ya está entre las favoritas", Color.Black);
			}
		}


		private void btnElimCryptoFav_Click(object sender, EventArgs e)
		{
			MostrarMensajeEnPanel(panel1, "", Color.Red);
			string criptoId = textidCryptoFav.Text.ToLower();

			if (criptoId.Length == 0)
			{
				log.Error("Debe ingresar el id de una crypto");
				MostrarMensajeEnPanel(panel1, "Debe ingresar el id de una crypto", Color.Black);
				return;
			}

			//obtenemos el usuario
			UsuarioDTO objetoUsuario = fachada.GetUsuarioActual();

			//ya está como favorito?
			if (fachada.ExisteCripto(criptoId)) //si está en favs
			{
				try
				{
					fachada.EliminarCryptoFav(objetoUsuario.idUsuario, criptoId);  //la agrega a favoritos
					MostrarMensajeEnPanel(panel1, "La crypto fue eliminada de favoritos", Color.Blue);
					
					//Grafico
					formsPlotFav.Plot.Clear(); // Limpia el gráfico antes de agregar nuevos datos
					mostrarDataFavoritas();

				}
				catch (Exception ex)
				{
					//Log.logger($"Error al agregar la cripto: {ex.Message}");
					MostrarMensajeEnPanel(panel1, $"Error al agregar la cripto: {ex.Message}", Color.Red);
				}
			}
			else
			{
				MostrarMensajeEnPanel(panel1, "La crypto no está entre las favoritas", Color.Red);
			}

		}

		// #### FIN BOTONES ####


		public void mostrarDataFavoritas()
		{
			//obtenemos el usuario
			UsuarioDTO objetoUsuario = fachada.GetUsuarioActual();
			//obtenemos las lista con todas las criptos favoritas
			var listaCryptosFav = fachada.CompararListaFavoritas(objetoUsuario);

			//las mostramos en el DataGrid
			dataGridFav.DataSource = listaCryptosFav;
			dataGridFav.Refresh();

			provider.NumberGroupSeparator = ",";
			provider.NumberDecimalSeparator = ".";

			//// Verificamos si la lista está vacía
			if (listaCryptosFav == null || listaCryptosFav.Count == 0)
			{
				MostrarMensajeEnPanel(panel1, "No hay criptomonedas favoritas.", Color.Red);
				return;
			}

			int i = 0;
			List<ScottPlot.Plottable.Bar> bars = new();
			foreach (var crypto in listaCryptosFav)  //itera sobre las fav para la barra del gráfico
			{
				i++;
				double value = double.Parse(crypto.priceUSD, provider);

				ScottPlot.Plottable.Bar bar = new()
				{
					Value = value,
					Position = i,
					FillColor = ScottPlot.Palette.Category10.GetColor(i),
					Label = crypto.name, //nombre de la cripto
					LineWidth = 4,
					LineColor = ScottPlot.Palette.Category10.GetColor(i),
				};
				bars.Add(bar);
			}
			//eje x
			double[] positions = new double[i + 1];
			string[] vacio = new string[i + 1];
			int k = 0;
			foreach (var crypto in listaCryptosFav)
			{
				k++;
				positions[k] = k;
				vacio[i] = "";

			}
			//actualizar gráfico
			formsPlotFav.Plot.XTicks(positions, vacio);
			formsPlotFav.Refresh();

			formsPlotFav.Plot.AddBarSeries(bars);
			formsPlotFav.Plot.SetAxisLimitsY(0, 500);
			formsPlotFav.Plot.XLabel("Criptomonedas favoritas");
			formsPlotFav.Plot.YLabel("Precio en USD");
			formsPlotFav.Refresh();
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
