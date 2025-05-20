using AutoMapper;
using Domain;
using Infrastructure.Repositories.IRepositories;
using Services.Dtos;
using Services.IServices;

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

    public async Task AddCriature(CriatureModel model)
    {
        
        await Repository.AddCriature(Mapper.Map<Criature>(model));
    }

    public async Task<List<CriatureModel>> GetAllCriatures()
    {
        var criatures = await Repository.GetAllCriatures();
        return Mapper.Map<List<CriatureModel>>(criatures);
    }

    public async Task UpdateCriature(CriatureModel criatureModel)
    {
        var criature = Mapper.Map<Criature>(criatureModel);
        await Repository.UpdateCriature(criature);
    }

    public async Task DeleteCriature(Guid id)
    {
        var criature = await Repository.GetCriatureById(id);
        if (criature != null)
        {
            await Repository.DeleteCriature(criature);
        }
    }
}
