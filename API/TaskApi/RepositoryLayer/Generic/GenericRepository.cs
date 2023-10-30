using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly TaskDBContext _taskDBContext;
        private readonly DbSet<T> table = null;
        public GenericRepository()
        {
            this._taskDBContext = new TaskDBContext();
            table = _taskDBContext.Set<T>();
        }
        public GenericRepository( TaskDBContext ventaDBContext)
        {
            this._taskDBContext = ventaDBContext;
            table = _taskDBContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.table.AsEnumerable();
        }

        public T GetById(object id)
        {
            return this.table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            this._taskDBContext.SaveChanges();
        }
    }
}
