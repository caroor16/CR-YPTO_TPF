using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.DAL
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);
		TEntity Get(string id);
		IEnumerable<TEntity> GetAll();
		void Remove(TEntity entity);
		void Save();
	}
}
