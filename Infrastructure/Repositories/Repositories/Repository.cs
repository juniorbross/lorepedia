using Domain;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Repositories
{
    public class Repository : BaseRepository, IRepository
    {
        public Repository(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task AddMilk(Milk milk)
        {
            try
            {
                Begin();
                context.Milks.Add(milk);
                await context.SaveChangesAsync();
                Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding milk", ex);
            }
        }

        public async Task<List<Milk>> GetAllMilks()
        {
            return await context.Milks.ToListAsync();
        }

        public async Task AddCriature(Criature criature)
        {
            try
            {
                Begin();
                context.Criatures.Add(criature);
                await context.SaveChangesAsync();
                Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding criature", ex);
            }
        }

        public async Task<List<Criature>> GetAllCriatures()
        {
            return await context.Criatures.ToListAsync();
        }

        // Método para obtener una criatura por su Id
        public async Task<Criature> GetCriatureById(Guid id)
        {
            return await context.Criatures.FindAsync(id);  // Devuelve la criatura o null si no se encuentra
        }

        // Método para actualizar una criatura
        public async Task UpdateCriature(Criature criature)
        {
            try
            {
                // Buscar la criatura existente por Id
                var existingCriature = await context.Criatures.FindAsync(criature.Id);
                if (existingCriature == null)
                {
                    throw new Exception("Criatura no encontrada");
                }

                // Actualizar los valores de la criatura
                existingCriature.Nombre = criature.Nombre;
                existingCriature.Tipo = criature.Tipo;
                existingCriature.Habitat = criature.Habitat;
                existingCriature.Alimentacion = criature.Alimentacion;
                existingCriature.Descripcion = criature.Descripcion;
                existingCriature.ImagenUrl = criature.ImagenUrl;
                existingCriature.niveldepeligro = criature.niveldepeligro;
                existingCriature.Preacaucion = criature.Preacaucion;
                // Guardar los cambios
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating criature", ex);
            }
        }

        // Método para eliminar una criatura
        public async Task DeleteCriature(Criature criature)
        {
            context.Criatures.Remove(criature);
            await context.SaveChangesAsync();
        }

    }
}
