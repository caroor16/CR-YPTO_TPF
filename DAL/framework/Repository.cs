using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CR_YPTO_TPF.DAL.framework
{
	public abstract class Repository<TDbContext, TEntity> : IRepository<TEntity> where TEntity : class where TDbContext : DbContext
	{
		protected readonly TDbContext iDbContext;

		public Repository(TDbContext pDbContext)
		{
			if (pDbContext == null)
			{
				throw new ArgumentNullException(nameof(pDbContext));
			}
			iDbContext = pDbContext;
		}

		public void Add(TEntity pEntity)
		{
			if (pEntity == null)
			{
				throw new ArgumentNullException(nameof(pEntity));
			}
			iDbContext.Set<TEntity>().Add(pEntity);
		}

		public TEntity Get(string pidUsuario)
		{
			return iDbContext.Set<TEntity>().Find(pidUsuario);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return iDbContext.Set<TEntity>();
		}

		public void Remove(TEntity pEntity)
		{
			if (pEntity == null)
			{
				throw new ArgumentNullException(nameof(pEntity));
			}
			iDbContext.Set<TEntity>().Remove(pEntity);
		}

		public void Save()
		{
			iDbContext.SaveChanges();
		}
	}
}
