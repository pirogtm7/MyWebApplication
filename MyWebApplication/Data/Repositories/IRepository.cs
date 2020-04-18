using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.Repositories
{
	public interface IRepository<TEntity> where TEntity : IBaseEntity
	{
		IEnumerable<TEntity> GetAll();
		void Add(TEntity entity);
		TEntity Get(int id);
		void Update(TEntity entity);
		void Delete(int id);
	}
}
