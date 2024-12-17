using BlazorVR.Context;
using BlazorVR.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorVR.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly DataContext _context;

        public WeatherService(DataContext context)
        {
            _context = context;
        }

        // ------------ 初期化 ------------
        public async Task InitialSetWeathers()
        {
            // いったん全件削除
            await _context.Weathers.ExecuteDeleteAsync();

            var weathers = GetInitialWeathers();
            _context.Weathers.AddRange(weathers);
            await _context.SaveChangesAsync();
        }

        private static readonly string[] summaries =
            new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private List<Weather> GetInitialWeathers()
        {
            DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);
            var weathers = Enumerable.Range(1, 50000).Select(index => new Weather
            {
                No = index,
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 45),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToList();

            return weathers;
        }


        // ------------ READ ------------
        // 全件取得
        public async Task<List<Weather>> GetAllWeathers()
        {
            var weathers = await _context.Weathers.ToListAsync();
            return weathers;
        }

        // 件数取得
        public async Task<int> GetWeatherCountAsync()
        {
            int totalCount = await _context.Weathers.CountAsync();
            return totalCount;
        }
        
        // 範囲取得
        public async Task<List<Weather>> GetRangeWeathers(int startIndex, int Count)
        {
            var weathers = await _context.Weathers
                .Skip(startIndex)
                .Take(Count)
                .OrderBy(x => x.No)
                .ToListAsync()
                ;

            return weathers;
        }

    }
}
