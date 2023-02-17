using TanksAPI.Models;

namespace TanksAPI.Repositories
{
    public interface ITanksRepository
    {
        Task<IEnumerable<Tank>> Get();
        Task<Tank> Get(int id);
        Task<Tank> Create(Tank tank);
        Task Update(Tank tank);
        Task Delete(int id);
    }
}
