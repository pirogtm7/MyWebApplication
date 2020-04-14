using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Entities;


namespace MyWebApplication.Data.Repositories
{
	public class ArtistRepository : IRepository<ArtistEntity>
	{
		private readonly MediaPlayerContext context;
		//private readonly DbSet<T> contextDbSet;
		private readonly List<ArtistEntity> contextList;


		public ArtistRepository(MediaPlayerContext context)
		{
			//contextDbSet = context.Set<T>();
			contextList = context.ArtistContextEntities;
		}

		public IEnumerable<ArtistEntity> GetAll()
		{
			//return contextDbSet.ToList();
			return contextList;
		}

		public void Add(ArtistEntity entity)
		{
			//contextDbSet.Add(entity);
			contextList.Add(entity);
		}

		public ArtistEntity Get(int id)
		{
			//return contextDbSet.Find(id);
			ArtistEntity e = null;
			foreach (ArtistEntity entity in contextList)
			{
				if (Convert.ToInt16(entity.Id) == id)
				{
					e = entity;
					break;
				}
			}
			return e;
		}

		public void Update(ArtistEntity entity)
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
			foreach (ArtistEntity e in contextList)
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
