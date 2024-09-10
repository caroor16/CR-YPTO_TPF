using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.Mail
{
	public interface IServicioMail
	{
		void mandarMail(string mensaje, string correo);
	}
}
