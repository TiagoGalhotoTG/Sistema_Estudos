using Microsoft.EntityFrameworkCore;
using Sistema_Estudos.API.Data;
using Sistema_Estudos.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco SqlLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Configuração do CORS para permitir acesso do react
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("ReactPolicy");
app.MapGet("/", () => "Sistema de Estudos - API funcionando!");

// Crud de matérias

// Get - Listar todas as matérias
app.MapGet("/api/materias", async (AppDbContext db) =>
{
    var materias = await db.Materias
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(materias);
});

// Get - Buscar matérias por ID
app.MapGet("/api/materias/{id}", async (int id, AppDbContext db) =>
{
    var materia = await db.Materias
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
    if (materia == null)
       return Results.NotFound("Matéria não encontrada.!");

    return Results.Ok(materia);
});

// Post - Cadastrar matéria
app.MapPost("/api/materias", async (Materia materia, AppDbContext db) =>
{
    db.Materias.Add(materia);
    await db.SaveChangesAsync();
    return Results.Created($"/api/materias/{materia.Id}", materia);
    
});

// Put - Atualizar matéria
app.MapPut("/api/materias/{id}", async (int id, Materia dados, AppDbContext db) =>
{
    var materia = await db.Materias.FindAsync(id);

    if (materia == null)
        return Results.NotFound("Matéria não encontrada!");

    materia.Nome = dados.Nome;
    materia.Descricao = dados.Descricao;

    await db.SaveChangesAsync();
    return Results.Ok(materia);
});

// Delete - Excluir matéria
app.MapDelete("/api/materias/{id}", async (int id, AppDbContext db) =>
{
    var materia = await db.Materias.FindAsync(id);

    if (materia == null)
        return Results.NotFound("Matérias não encontrada!");
    
    db.Materias.Remove(materia);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

