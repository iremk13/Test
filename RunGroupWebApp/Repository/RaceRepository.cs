using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDBContext _context;

        public RaceRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public bool Add(Races race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Races race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Races>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Races> GetByIDAsync(int id)
        {
            return await _context.Races.Include(i=>i.Address).Include(i=>i.AppUser).FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<IEnumerable<Races>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(a => a.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Races race)
        {
            _context.Update(race);
            return Save();
        }

      
    }
}
