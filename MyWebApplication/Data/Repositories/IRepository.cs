using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Repositories
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		void Add(T item);
		T Get(int id);
		void Update(T item);
		void Delete(int id);
		void Save();
	}
}
