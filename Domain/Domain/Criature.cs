using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Criature : BaseEntity
    {
        public virtual string Nombre { get; set; }
        public virtual string NombreCientifico { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Habitat { get; set; }
        public virtual string Alimentacion { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string ImagenUrl { get; set; }
    }
}

