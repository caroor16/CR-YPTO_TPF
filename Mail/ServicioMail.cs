using CR_YPTO_TPF.DAL.framework;
using CR_YPTO_TPF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Mail
{
	public class ServicioMail : IServicioMail
	{
		Fachada fachada = new Fachada();
		public void mandarMail(string mensaje, string correo)
		{
			string correoOrigen = "";
			string claveOrigen = "";
			
			MailMessage message = new MailMessage();
			message.From = new MailAddress(correoOrigen);
			message.Subject = "Alertas de tendencia";
			message.To.Add(new MailAddress(correo)); //correo destinatario
			message.Body = mensaje;
		}

		public void ConstruirMensaje()
		{
			StringBuilder mensaje = new StringBuilder();
			AppDbContext context = new AppDbContext();
			
			mensaje.AppendLine("\n Equipo de CR-YPTO");
		}
	}
}
