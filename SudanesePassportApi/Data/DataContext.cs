using Microsoft.EntityFrameworkCore;
using SudanesePassportApi.Models.SudaneseCard;

namespace SudanesePassportApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Card> Cards { get; set; }
}
