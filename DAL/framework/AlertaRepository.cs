using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CR_YPTO_TPF.Domain;
using CR_YPTO_TPF.DAL;

namespace CR_YPTO_TPF.DAL.framework
{
	public class AlertaRepository : Repository<AppDbContext, alerta>, IAlertaRepository
	{
		public AlertaRepository(AppDbContext oAppDbContext) : base(oAppDbContext) { }
	}
}


