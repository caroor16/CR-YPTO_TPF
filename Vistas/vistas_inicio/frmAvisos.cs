using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	public partial class frmAvisos : Form
	{
		fachada fachada = new fachada();
		log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");
		NumberFormatInfo provider = new NumberFormatInfo();
		DateTime lastAlertaTime = DateTime.Now.AddHours(-24); // Inicializa para evitar errores
		int j = 0; // Declaración de j
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

		public frmAvisos()
		{
			InitializeComponent();
			// Configuración del temporizador
			timer.Interval = 1000; // Ajusta la frecuencia
			timer.Tick += (sender, e) => temporizador(); // Evento para cada tick del temporizador
			timer.Start();

			//avisosTiempo();    
		}

		// Método para mostrar las alertas
		public void mostrarAlertas()
		{
			try
			{
				// Mostrar el umbral del usuario en pantalla
				usuarioDTO usuario = fachada.GetUsuarioActual();
				string umbralUs = usuario.umbral.ToString();

				// Etiqueta para mostrar el umbral
				System.Windows.Forms.Label labelUm = new System.Windows.Forms.Label();
				labelUm.Text = umbralUs;
				labelUm.ForeColor = Color.Black;
				labelUm.Font = new Font("Arial", 9.8f);

				// Agrega la etiqueta al panel
				panel1.Controls.Add(labelUm);

				// Obtener la lista de criptos favoritas
				List<(string criptoId, decimal cambio24hs)> listaAlertas = fachada.GetAlertas();

				if (listaAlertas.Count > 0)
				{
					foreach (var alerta in listaAlertas)
					{
						this.Invoke(new MethodInvoker(delegate ()
						{
							notificiaciones.Items.Add($"La criptomoneda ' {alerta.criptoId} ' superó el umbral en un {alerta.cambio24hs:0.0000}%");
							j++;
							notificiaciones.Refresh();
						}));
					}
				}
				else
				{
					this.Invoke(new MethodInvoker(delegate ()
					{
						System.Windows.Forms.Label panel = new System.Windows.Forms.Label();
						panel.Text = "No hay alertas";
						panel.AutoSize = true;
						panel.ForeColor = Color.White;
						panel.Font = new Font("Arial", 9.8f);
						panelFinCambios.Controls.Add(panel);
					}));
				}

				// Actualizar el tiempo de la última alerta
				lastAlertaTime = DateTime.Now;
			}
			catch (Exception ex)
			{
				// Registrar la excepción para depuración
				log.logger("Error mostrando alertas: " + ex.Message);
			}
		}

		

		// Método manejador del temporizador
		private void temporizador()
		{
			try
			{
				// Mostrar las alertas cada 24 horas
				mostrarAlertas();

				// Configurar el temporizador para ejecutarse cada 24 horas
				timer.Interval = 86400000; // 24 horas en milisegundos
			}
			catch (Exception ex)
			{
				// Registrar el error en los logs
				log.logger("Error en HandleTimer: " + ex.Message);
			}
		}
	}
}
