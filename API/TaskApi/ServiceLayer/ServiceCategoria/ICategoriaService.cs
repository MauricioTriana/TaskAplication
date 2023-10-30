using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceCategoria
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Categoria GetCategoria(int id);
        void Insert(Categoria entity);
        void Update(Categoria entity);
        void Remove(int id);
    }
}
