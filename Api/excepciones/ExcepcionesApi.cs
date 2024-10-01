using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Api.excepciones
{
	internal class ExcepcionesApi : ApplicationException
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public ExcepcionesApi(string mensaje) : base(mensaje)
		{
			log.Error("Error Api: {0} " + mensaje);
		}
	}
}
