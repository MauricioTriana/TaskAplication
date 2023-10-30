using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceTarea
{
    public interface ITareaService
    {
        IEnumerable<Tarea> GetAll();
        Tarea GetTarea(int id);
        void Insert(Tarea entity);
        void Update(Tarea entity);
        void Remove(int id);
    }
}
