using Services.Dtos;

namespace Services.IServices
{
    public interface IService
    {
        Task AddCriature(CriatureModel model);
        Task UpdateCriature(CriatureModel criatureModel);  // Cambié esto para que reciba un objeto de tipo CriatureModel
        Task DeleteCriature(Guid id);


        Task AddMilk(int v, DateTime now);
        Task<List<CriatureModel>> GetAllCriatures();
        Task<List<MilkModel>> GetAllMilks();
    }
}
