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
    }
}
