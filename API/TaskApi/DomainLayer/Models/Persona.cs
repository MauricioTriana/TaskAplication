using System;
using System.Collections.Generic;

#nullable disable

namespace DomainLayer.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long? Telefono { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
