using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.DAL;
using CR_YPTO_TPF.DAL.framework;
using Microsoft.EntityFrameworkCore;

namespace CR_YPTO_TPF.DAL.framework
{
	public class UnitOfWork : IUnitOfWork
	{

		public readonly AppDbContext iDbContext;

		private bool iDisposedValue = false;

		public UnitOfWork(AppDbContext pDbContext)
		{
			if (pDbContext == null)
			{
				throw new NotImplementedException();
			}

			this.iDbContext = pDbContext;
			this.UsuarioRepository = new UsuarioRepository(pDbContext);
		}


		public IAlertaRepository AlertaRepository { get; private set; }
		public IUsuarioRepository UsuarioRepository { get; private set; }

		public void Complete()
		{
			this.iDbContext.SaveChanges();
		}

		protected virtual void Dispose(bool pDisposing)
		{
			if (!this.iDisposedValue)
			{
				if (pDisposing)
				{
					this.iDbContext.Dispose();
				}
				this.iDisposedValue = true;
			}
		}
		public void Dispose()
		{
			this.Dispose(true);
		}
	}
}
