using AutoMapper;
using Domain;
using Infrastructure.Repositories.IRepositories;
using Services.Dtos;
using Services.IServices;

namespace Services.Services
{
    public class Service : IService
    {
        private IRepository Repository { get; set; }
        private IMapper Mapper { get; set; }

        public Service(IRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<List<MilkModel>> GetAllMilks()
        {
            return Mapper.Map<List<MilkModel>>(await Repository.GetAllMilks());
        }

        public async Task AddMilk(int liters, DateTime dateTime)
        {
            Milk m = new Milk();
            m.Liters = liters;
            m.RecolectionDate = dateTime;
            await Repository.AddMilk(m);
        }

        // Implementación de AddCriature para crear una nueva Criature
        public async Task AddCriature(CriatureModel model)
        {
            

            // Añadimos la Criature al repositorio
            await Repository.AddCriature(Mapper.Map<Criature>(model));
        }

        // Obtener todas las Criatures
        async Task<List<CriatureModel>> IService.GetAllCriatures()
        {
            var criatures = await Repository.GetAllCriatures();
            return Mapper.Map<List<CriatureModel>>(criatures);
        }
        // Implementación de UpdateCriature usando el modelo CriatureModel
        public async Task UpdateCriature(CriatureModel criatureModel)
        {
            // Convertir el modelo DTO a entidad
            var criature = Mapper.Map<Criature>(criatureModel);

            // Verificar si la criatura existe
            var existingCriature = await Repository.GetCriatureById(criature.Id);
            if (existingCriature == null)
            {
                throw new Exception("Criatura no encontrada");
            }

            // Actualizar la criatura
            await Repository.UpdateCriature(criature);
        }

        // eliminar una Criature
        public async Task DeleteCriature(Guid id)
        {
            var criature = await Repository.GetCriatureById(id);
            if (criature == null)
                throw new Exception("Criatura no encontrada");

            await Repository.DeleteCriature(criature);
        }


    }
}
