using CR_YPTO_TPF.Vistas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Windows.Forms;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.Api;

namespace CR_YPTO_TPF
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var services = ConfigureServices();

			using (var serviceProvider = services.BuildServiceProvider())
			{
				var loginForm = serviceProvider.GetRequiredService<Login>();
				Application.Run(loginForm);
			}
		}

		static IServiceCollection ConfigureServices()
		{
			var services = new ServiceCollection();

			// Registrar DbContext sin cadena de conexión explícita, ya que se configura en AppDbContext
			services.AddDbContext<AppDbContext>();

			// Registrar Repositorios
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();

			// Registrar la clase fachada
			services.AddScoped<fachada>();

			// Registrar Formularios
			services.AddScoped<Login>();
			services.AddScoped<registrarse>();

			//// Api
			//// Registrar HttpClient y el servicio de criptomonedas
			//services.AddSingleton<IApiResponsive, ApiReponsive>();


			return services;
		}
	}
}
