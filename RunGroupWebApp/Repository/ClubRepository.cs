using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDBContext _context;

        public ClubRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            //burada clubs applicationdbcontext dbsetteki adı olmalı model adı değil!!!
            return await _context.Clubs.ToListAsync();
        }

        //detay görüntülemek için
        public async Task<Club> GetByIDAsync(int id)
        {
            //id ile gösterirken bile include ile adresi bağlamamız lazım çünkü tabloyu baska bir tablo ile 
            //(adres)bağladın
            
            return await _context.Clubs.Include(i=>i.Address).FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(a => a.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
