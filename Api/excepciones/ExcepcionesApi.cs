using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Api.excepciones
{
	internal class ExcepcionesApi : ApplicationException
	{
		//log log = new log(@"C:\Users\Carolina r\source\repos\proyectos\PROYECTO-TALLER\CR-YPTO\CR-YPTO_TPF\log");
		public ExcepcionesApi(string mensaje) : base(mensaje)
		{
			//log.logger("Error Api: {0} " + mensaje);
		}
	}
}
