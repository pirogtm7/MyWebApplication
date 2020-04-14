//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using MyWebApplication.Data.Entities;

//namespace MyWebApplication.Data.Repositories
//{
//	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
//	{
//		private readonly MediaPlayerContext context;
//		//private readonly DbSet<T> contextDbSet;
//		private readonly List<TEntity> contextList;


//		public Repository(MediaPlayerContext context, List<TEntity> contextList)
//		{
//			//contextDbSet = context.Set<T>();
//			this.context = context;
//			this.contextList = contextList;
//		}

//		public IEnumerable<TEntity> GetAll()
//		{
//			//return contextDbSet.ToList();
//			return contextList;
//		}

//		public void Add(TEntity entity)
//		{
//			//contextDbSet.Add(entity);
//			contextList.Add(entity);
//		}

//		public TEntity Get(int id)
//		{
//			//return contextDbSet.Find(id);
//			TEntity e = null;
//			foreach (TEntity entity in contextList)
//			{
//				if (Convert.ToInt16(entity.Id) == id)
//				{
//					e = entity;
//					break;
//				}
//			}
//			return e;
//		}

//		public void Update(TEntity entity)
//		{
//			////contextDbSet.Update(entity);
//			//TEntity upde = null;

//			//foreach (TEntity e in contextList)
//			//{
//			//	if (e == entity)
//			//	{
//			//		upde = e;
//			//		contextList.Remove(e);
//			//		contextList.Add
//			//		break;
//			//	}
//			//}
//		}

//		public void Delete(int id)
//		{
//			//var tEntity = contextDbSet.Find(id);

//			//if (tEntity != null)
//			//{
//			//	contextDbSet.Remove(tEntity);
//			//}
//			foreach (TEntity e in contextList)
//			{
//				if (Convert.ToInt16(e.Id) == id)
//				{
//					contextList.Remove(e);
//					break;
//				}
//			}
//		}

//		//public void Save()
//		//{
//		//	context.SaveChanges();
//		//}
//	}
//}
