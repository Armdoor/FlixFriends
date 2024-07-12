using FlixFriends.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixFriends.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movies> Movies { get; set; }
    public DbSet<Series> Series { get; set; }
}