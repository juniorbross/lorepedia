using Domain;

namespace Infrastructure.Repositories.IRepositories
{
    public interface IRepository
    {
        Task AddCriature(Criature criature);
        Task AddMilk(Milk milk);
        
        Task<List<Criature>> GetAllCriatures(); // ✅ Corrección aplicada aquí
        Task<List<Milk>> GetAllMilks();
    }
}
