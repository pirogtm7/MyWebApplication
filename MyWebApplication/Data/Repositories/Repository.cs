using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly MediaPlayerContext context;
		private readonly DbSet<T> contextDbSet;

		public Repository(MediaPlayerContext context)
		{
			contextDbSet = context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return contextDbSet.ToList();
		}

		public void Add(T entity)
		{
			contextDbSet.Add(entity);
		}

		public T Get(int id)
		{
			return contextDbSet.Find(id);
		}

		public void Update(T entity)
		{
			contextDbSet.Update(entity);
		}

		public void Delete(int id)
		{
			var tEntity = contextDbSet.Find(id);

			if (tEntity != null)
			{
				contextDbSet.Remove(tEntity);
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
