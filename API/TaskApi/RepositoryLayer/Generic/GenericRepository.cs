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
            try
            {
                this._taskDBContext = ventaDBContext;
                table = _taskDBContext.Set<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this.table.AsEnumerable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(object id)
        {
            try
            {
                return this.table.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }

        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save()
        {
            try
            {
                this._taskDBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
