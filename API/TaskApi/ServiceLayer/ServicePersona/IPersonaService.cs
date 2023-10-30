using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServicePersona
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetAll();
        Persona GetPersona(int id);

        Persona GetPersonaByIdentificacion(string id);
        void Insert(Persona entity);
        void Update(Persona entity);
        void Remove(int id);
        Boolean Login(string id, string pass);
    }
}
