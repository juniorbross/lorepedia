using Domain;

namespace Infrastructure.Repositories.IRepositories
{
    public interface IRepository
    {
        Task AddCriature(Criature criature);
        Task AddMilk(Milk milk);
        Task UpdateCriature(Criature criature);
        Task DeleteCriature(Criature criature);


        Task<List<Criature>> GetAllCriatures(); // ✅ Corrección aplicada aquí
        Task<List<Milk>> GetAllMilks(); // Asegúrate de que esté definida esta firma

        Task<Criature> GetCriatureById(Guid id);

    }
}
