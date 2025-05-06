using Services.Dtos;

namespace Services.IServices
{
    public interface IService
    {
        Task AddCriature(string nombre, string nombreCientifico, string tipo, string habitat, string alimentacion, string descripcion, string imagenUrl);
        Task AddMilk(int v, DateTime now);
        Task<List<CriatureModel>> GetAllCriatures();
        Task<List<MilkModel>> GetAllMilks();
    }
}
