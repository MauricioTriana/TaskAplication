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
            return _genericRepository.GetAll();
        }

        public Tarea GetTarea(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Insert(Tarea entity)
        {
            _genericRepository.Insert(entity);
            _genericRepository.Save();
        }

        public void Update(Tarea entity)
        {
            _genericRepository.Update(entity);
            _genericRepository.Save();
        }

        public void Remove(int id)
        {
            _genericRepository.Delete(id);
            _genericRepository.Save();
        }
    }
}
