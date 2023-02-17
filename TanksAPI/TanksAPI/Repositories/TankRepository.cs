using Microsoft.EntityFrameworkCore;
using TanksAPI.Models;

namespace TanksAPI.Repositories
{
    public class TankRepository : ITanksRepository
    {
        private readonly TankContext _context;
        public TankRepository(TankContext context)
        {
            _context = context;
        }

        async Task<Tank> ITanksRepository.Create(Tank tank)
        {
            _context.Tanks.Add(tank);
            await _context.SaveChangesAsync();
            return tank;
        }

        async Task ITanksRepository.Delete(int id)
        {
            var TankToDelete = await _context.Tanks.FindAsync(id);
            _context.Tanks.Remove(TankToDelete);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Tank>> ITanksRepository.Get()
        {
            return await _context.Tanks.ToListAsync();
        }

        async Task<Tank> ITanksRepository.Get(int id)
        {
            return await _context.Tanks.FindAsync(id);
        }

        async Task ITanksRepository.Update(Tank tank)
        {
            _context.Entry(tank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
