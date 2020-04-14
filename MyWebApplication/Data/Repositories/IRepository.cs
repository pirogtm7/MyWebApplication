using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.Repositories
{
	public interface IRepository<T> where T : IBaseEntity
	{
		IEnumerable<T> GetAll();
		void Add(T item);
		T Get(int id);
		void Update(T item1, T item2);
		void Delete(int id);
		//void Save();
	}
}
