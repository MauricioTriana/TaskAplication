using System;
using System.Collections.Generic;

#nullable disable

namespace DomainLayer.Models
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IdPersona { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
