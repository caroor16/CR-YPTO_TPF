using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System.Collections.Specialized;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.DTOs;
using CR_YPTO_TPF.Vistas;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Quartz.Logging.OperationName;
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

			var servicesM = ConfigureServices();

			using (var serviceProvider = servicesM.BuildServiceProvider())
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

			return services;
		}
	}
}
