using DomainLayer.Models;
using RepositoryLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceCategoria
{
    public class CategoriaService: ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _genericRepository = null;

        public CategoriaService(IGenericRepository<Categoria> repositoryCategoria)
        {
            this._genericRepository = repositoryCategoria;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public Categoria GetCategoria(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Insert(Categoria entity)
        {
            _genericRepository.Insert(entity);
            _genericRepository.Save();
        }

        public void Update(Categoria entity)
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
