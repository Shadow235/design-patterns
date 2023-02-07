using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericJsonRepository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly List<T> _entities;
		private readonly string _filePath;

		public Repository(string filePath)
		{
			_filePath = filePath;
			if (File.Exists(filePath))
			{
				var json = File.ReadAllText(filePath);
				_entities = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
			}
			else
			{
				_entities = new List<T>();
			}
		}

		public IEnumerable<T> GetAll()
		{
			return _entities;
		}

		public T GetById(int id)
		{
			return _entities.Find(e => e.GetHashCode() == id);
		}

		public void Add(T entity)
		{
			_entities.Add(entity);
		}

		public void Update(T entity)
		{
			var index = _entities.FindIndex(e => e.GetHashCode() == entity.GetHashCode());
			if (index >= 0)
			{
				_entities[index] = entity;
			}
		}

		public void Delete(int id)
		{
			var entity = GetById(id);
			if (entity != null)
			{
				_entities.Remove(entity);
			}
		}

		public void SaveChanges()
		{
			var json = JsonConvert.SerializeObject(_entities, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(_filePath, json);
		}
	}

}
