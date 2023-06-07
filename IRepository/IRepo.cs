using CupInfo;

namespace IRepository
{
    public interface IRepo
    {
        Task<List<Countries>> GetCountries(string country);
        Task<List<SoccerMatch>> GetPlayers(string fifa_code);
        Task<List<SoccerMatch>> GetStats(string apiCode);
    }
}