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

        public async Task AddCriature(string nombre, string nombreCientifico, string tipo, string habitat, string alimentacion, string descripcion, string imagenUrl)
        {
            var criature = new Criature
            {
                Nombre = nombre,
                NombreCientifico = nombreCientifico,
                Tipo = tipo,
                Habitat = habitat,
                Alimentacion = alimentacion,
                Descripcion = descripcion,
                ImagenUrl = imagenUrl
            };

            await Repository.AddCriature(criature);
        }

        public async Task<List<CriatureModel>> GetAllCriatures()
        {
            var criatures = await Repository.GetAllCriatures();
            return Mapper.Map<List<CriatureModel>>(criatures);
        }
    }
}
