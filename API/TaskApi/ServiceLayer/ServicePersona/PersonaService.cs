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
            try
            {
                return _genericRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public Persona GetPersona(int id)
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

        public Boolean Login(string id, string pass)
        {
            try
            {
                Persona persona = _genericRepository.GetAll().Where(x => x.Cedula.Equals(id)).FirstOrDefault();
                return (persona != null) && (!string.IsNullOrEmpty(persona.Clave) && persona.Clave.Equals(pass));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Persona entity)
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

        public void Update(Persona entity)
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

        public Persona GetPersonaByIdentificacion(string id)
        {
            try
            {
                Persona persona = _genericRepository.GetAll().Where(x => x.Cedula.Equals(id)).FirstOrDefault();
                return persona;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
