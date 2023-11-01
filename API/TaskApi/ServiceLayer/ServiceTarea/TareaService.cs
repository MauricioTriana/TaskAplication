using DomainLayer.Models;
using RepositoryLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceTarea
{
    public class TareaService: ITareaService
    {
        private readonly IGenericRepository<Tarea> _genericRepository = null;

        public TareaService(IGenericRepository<Tarea> repositoryTarea)
        {
            this._genericRepository = repositoryTarea;
        }

        public IEnumerable<Tarea> GetAll()
        {
            try
            {
                return _genericRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Tarea GetTarea(int id)
        {
            try
            {
                return _genericRepository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Insert(Tarea entity)
        {
            try
            {
                _genericRepository.Insert(entity);
                _genericRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Update(Tarea entity)
        {
            try
            {
                _genericRepository.Update(entity);
                _genericRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Remove(int id)
        {
            try
            {
                _genericRepository.Delete(id);
                _genericRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
