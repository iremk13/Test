using RunGroupWebApp.Models;

namespace RunGroupWebApp.Interface
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Races>> GetAll();
        Task<Races> GetByIDAsync(int id);
        Task<IEnumerable<Races>> GetAllRacesByCity(string city);
        bool Add(Races race);
        bool Update(Races race);
        bool Delete(Races race);
        bool Save();
    }
}
