using BlazorVR.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorVR.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public required DbSet<Weather> Weathers { get; set; }

    }
}
