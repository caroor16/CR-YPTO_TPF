using CR_YPTO_TPF.Api;
using CR_YPTO_TPF.Api.excepciones;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ScottPlot;
using log4net;
using static ScottPlot.Plottable.PopulationPlot;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmCrypto : Form
	{
		Fachada fachada = new Fachada();
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		NumberFormatInfo provider = new NumberFormatInfo();

		public frmCrypto()
		{
			InitializeComponent();
			datosCryptos();

		}

		private void frmCrypto_Load(object sender, EventArgs e) { }

		public void datosCryptos()  //de las cryptos
		{
			try
			{
				var respuesta = fachada.GetCryptosTodas();
				dataGridView1.DataSource = respuesta;
				dataGridView1.Refresh();

				provider.NumberGroupSeparator = ",";
				provider.NumberDecimalSeparator = ".";
				PlotGeneral.Plot.Clear(); // Limpia el gráfico antes de agregar nuevos datos
				//var cryptosDTO = fachada.GetCryptosTodas();
				int i = 0;
				List<ScottPlot.Plottable.Bar> bars = new();
				foreach (var crypto in respuesta)
				{
					i++;
					double value = double.Parse(crypto.priceUSD, provider);

					ScottPlot.Plottable.Bar bar = new()
					{
						Value = value,
						Position = i,
						FillColor = ScottPlot.Palette.Category10.GetColor(i),
						Label = crypto.name,
						LineWidth = 4,
						LineColor = ScottPlot.Palette.Category10.GetColor(i),
					};
					bars.Add(bar);
				}
				double[] positions = new double[i + 1];
				string[] vacio = new string[i + 1];
				int k = 0;
				foreach (var crypto in respuesta)
				{
					k++;
					positions[k] = k;
					vacio[k] = "";
				}
				PlotGeneral.Plot.XTicks(positions, vacio);
				PlotGeneral.Refresh();

				//las barras por cada cripto
				PlotGeneral.Plot.AddBarSeries(bars);
				PlotGeneral.Plot.SetAxisLimitsY(0, 3500);
				PlotGeneral.Plot.YLabel("Precio en USD");
				PlotGeneral.Plot.XLabel("Criptomonedas");
				PlotGeneral.Refresh();
				int j = 0;

			}
			catch (ExcepcionesApi unaExcepcion)
			{
				log.Error("Error: {0} " + unaExcepcion.Message);
				MessageBox.Show(unaExcepcion.Message);
				Application.Exit();
			}
		}

		//BOTONES
		private void btnBuscarCrypto_Click(object sender, EventArgs e)
		{
			
			try
			{	
				MostrarMensajeEnPanel(panel1, "", Color.White); // para q en cada intento se borre
				//obtiene el historial de las criptos
				var respuesta = fachada.ObtenerHistorialCripto(textidcrypto.Text.ToLower());
				if (textidcrypto.Text.ToLower() == "")
				{
					MostrarMensajeEnPanel(panel1, "Debe ingresar el ID de una criptomoneda", Color.Red);
				}
				else if (respuesta.Count == 0 ) //verifica si se encontraron resultados
				{
					MostrarMensajeEnPanel(panel1, "No se encontró la criptomoneda ingresada", Color.Red);
				}
				else
				{
					//si encuentra
					MostrarMensajeEnPanel(panel1, "", Color.White); //para que elimine los mensajes anteriores

					PlotGeneral.Plot.Clear(); // Limpia el gráfico antes de agregar nuevos datos
					int i = 0;
					provider.NumberGroupSeparator = ","; //para q el separador de miles sea un punto
					provider.NumberDecimalSeparator = "."; //coma para separador decimal 1.000,58

					// prepara los datos del gráfico
					
					List<ScottPlot.Plottable.Bar> bars = new();
					foreach (var crypto in respuesta)
					{
						i++;
						double value = double.Parse(crypto.PriceUSD, provider);
						ScottPlot.Plottable.Bar bar = new()
						{
							Value = value,
							Position = i,
							FillColor = ScottPlot.Palette.Category10.GetColor(i),
							Label = "",
							LineWidth = 4,
							LineColor = ScottPlot.Palette.Category10.GetColor(i),
						};
						bars.Add(bar);
					}
					int j = 0;
					string[] fechas = new string[i + 1];
					double[] positions = new double[i + 1];
					foreach (var crypto in respuesta)
					{
						j++;
						positions[j] = j;
						fechas[j] = crypto.Time.ToString();
					}
					
					// configuración del gráfico //dataGridView1  PlotGeneral
					PlotGeneral.Plot.AddBarSeries(bars);
					PlotGeneral.Plot.SetAxisLimitsY(0, 500);
					PlotGeneral.Plot.XTicks(positions, fechas);
					PlotGeneral.Plot.YLabel("Precio en USD");
					PlotGeneral.Plot.XLabel("Fecha y Hora");
					dataGridView1.DataSource = respuesta;
					//dataGridView1.Columns["idCryptoHistoria"].Visible = false;
					//dataGridView1.Columns["idUsuario"].Visible = false;
					PlotGeneral.Refresh();
					MostrarMensajeEnPanel(panel1, "Crypto encontrada", Color.Blue);

				}


			}
			catch (ExcepcionesApi unaExcepcion)
			{
				log.Error("Error: {0} " + unaExcepcion.Message);
				MessageBox.Show(unaExcepcion.Message);
				Application.Exit();
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


		private void btnMostrar_Click(object sender, EventArgs e)
		{
			datosCryptos();
		}

		private void PlotGeneral_Load(object sender, EventArgs e)
		{

		}

		
	}
}
