using MyWebApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Repositories
{
	public class AlbumRepository : IRepository<AlbumEntity> 
	{
		private readonly MediaPlayerContext context;
		//private readonly DbSet<T> contextDbSet;
		private readonly List<AlbumEntity> contextList;


		public AlbumRepository(MediaPlayerContext context)
		{
			//contextDbSet = context.Set<T>();
			contextList = context.AlbumContextEntities;
		}

		public IEnumerable<AlbumEntity> GetAll()
		{
			//return contextDbSet.ToList();
			return contextList;
		}

		public void Add(AlbumEntity entity)
		{
			//contextDbSet.Add(entity);
			contextList.Add(entity);
		}

		public AlbumEntity Get(int id)
		{
			//return contextDbSet.Find(id);
			AlbumEntity e = null;
			foreach (AlbumEntity entity in contextList)
			{
				if (Convert.ToInt16(entity.Id) == id)
				{
					e = entity;
					break;
				}
			}
			return e;
		}

		public void Update(AlbumEntity entity)
		{
			////contextDbSet.Update(entity);
			//TEntity upde = null;

			//foreach (TEntity e in contextList)
			//{
			//	if (e == entity)
			//	{
			//		upde = e;
			//		contextList.Remove(e);
			//		contextList.Add
			//		break;
			//	}
			//}
		}

		public void Delete(int id)
		{
			//var tEntity = contextDbSet.Find(id);

			//if (tEntity != null)
			//{
			//	contextDbSet.Remove(tEntity);
			//}
			foreach (AlbumEntity e in contextList)
			{
				if (Convert.ToInt16(e.Id) == id)
				{
					contextList.Remove(e);
					break;
				}
			}
		}

		//public void Save()
		//{
		//	context.SaveChanges();
		//}
	}
}
