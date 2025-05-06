using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class CriatureModels
    {
        public List<CriatureModel> Criatures { get; set; }

        public CriatureModels()
        {
            Criatures = new List<CriatureModel>();
        }
    }

    public class CriatureModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public string Tipo { get; set; }
        public string Habitat { get; set; }
        public string Alimentacion { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }

        public CriatureModel()
        {
            Id = Guid.NewGuid(); // Para que cada Criature tenga un ID único
        }
    }
}
