using Microsoft.EntityFrameworkCore;
using Sistema_Estudos.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco SqlLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
var app = builder.Build();

app.MapGet("/", () => "Sistema de Estudos - API funcionando!");

app.Run();
