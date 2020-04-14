using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Entities;


namespace MyWebApplication.Data.Repositories
{
	public class TrackRepository : IRepository<TrackEntity>
	{
		private readonly MediaPlayerContext context;
		//private readonly DbSet<T> contextDbSet;
		private readonly List<TrackEntity> contextList;


		public TrackRepository(MediaPlayerContext context)
		{
			//contextDbSet = context.Set<T>();
			contextList = context.TrackContextEntities;
		}

		public IEnumerable<TrackEntity> GetAll()
		{
			//return contextDbSet.ToList();
			return contextList;
		}

		public void Add(TrackEntity entity)
		{
			//contextDbSet.Add(entity);
			contextList.Add(entity);
		}

		public TrackEntity Get(int id)
		{
			//return contextDbSet.Find(id);
			TrackEntity e = null;
			foreach (TrackEntity entity in contextList)
			{
				if (Convert.ToInt16(entity.Id) == id)
				{
					e = entity;
					break;
				}
			}
			return e;
		}

		public void Update(TrackEntity entity)
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
			foreach (TrackEntity e in contextList)
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
