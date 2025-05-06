using Services.Dtos;

namespace Services.Common
{
    public class MProfile : AutoMapper.Profile
    {
        public MProfile()
        {
            MilkMapper();
            CriatureMapper();  // Llamamos al mapeo de Criature
        }

        private void MilkMapper()
        {
            CreateMap<Domain.Milk, MilkModel>()
              .ReverseMap(); // Para permitir la conversión en ambos sentidos
        }

        private void CriatureMapper()
        {
            CreateMap<Domain.Criature, CriatureModel>()
              .ReverseMap(); // Para permitir la conversión en ambos sentidos
        }
    }
}
