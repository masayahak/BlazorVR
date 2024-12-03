using BlazorVR.Models;
namespace BlazorVR.Services
{
    public interface IWeatherService
    {
        // ------------ 初期化 ------------
        Task InitialSetWeathers();

        // ------------ READ ------------
        Task<List<Weather>> GetAllWeathers();
        Task<int> GetWeatherCountAsync();
        Task<List<Weather>> GetRangeWeathers(int startIndex, int Count);
    }
}
