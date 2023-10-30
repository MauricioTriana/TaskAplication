using System;
using System.Collections.Generic;

#nullable disable

namespace DomainLayer.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
