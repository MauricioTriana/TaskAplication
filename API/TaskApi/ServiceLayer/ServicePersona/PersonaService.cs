using DomainLayer.Models;
using RepositoryLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServicePersona
{
    public class PersonaService: IPersonaService
    {
        private readonly IGenericRepository<Persona> _genericRepository = null;

        public PersonaService(IGenericRepository<Persona> repositoryPersona)
        {
            this._genericRepository = repositoryPersona;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public Persona GetPersona(int id)
        {
            return _genericRepository.GetById(id);
        }

        public Boolean Login(string id, string pass)
        {
            Persona persona = _genericRepository.GetAll().Where(x => x.Cedula.Equals(id)).FirstOrDefault();
            return (persona != null) && (!string.IsNullOrEmpty(persona.Clave) && persona.Clave.Equals(pass));
        }

        public void Insert(Persona entity)
        {
            _genericRepository.Insert(entity);
            _genericRepository.Save();
        }

        public void Update(Persona entity)
        {
            _genericRepository.Update(entity);
            _genericRepository.Save();
        }

        public void Remove(int id)
        {
            _genericRepository.Delete(id);
            _genericRepository.Save();
        }

        public Persona GetPersonaByIdentificacion(string id)
        {
            Persona persona = _genericRepository.GetAll().Where(x => x.Cedula.Equals(id)).FirstOrDefault();
            return persona;
        }
    }
}
