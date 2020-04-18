using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly DbSet<TEntity> contextDbSet;
		private readonly MediaPlayerContext context;

		public Repository(MediaPlayerContext context)
		{
			contextDbSet = context.Set<TEntity>();
			this.context = context;
		}

		public IEnumerable<TEntity> GetAll()
		{
			return contextDbSet.ToList();
		}

		public void Add(TEntity entity)
		{
			contextDbSet.Add(entity);
		}

		public TEntity Get(int id)
		{
			return contextDbSet.Find(id);
		}

		public void Update(TEntity entity)
		{
			contextDbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var tEntity = contextDbSet.Find(id);
			if (tEntity != null)
			{
				contextDbSet.Remove(tEntity);
			}
		}
	}
}
