using Microsoft.EntityFrameworkCore;
using Sistema_Estudos.API.Models;

namespace Sistema_Estudos.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
    : base(options)
    {
    }

    public DbSet<Materia> Materias {get; set;} 
    public DbSet<Atividade> Atividades {get; set;}
}