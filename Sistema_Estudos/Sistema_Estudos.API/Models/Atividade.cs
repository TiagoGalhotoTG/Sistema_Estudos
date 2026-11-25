using System.ComponentModel.DataAnnotations;

namespace Sistema_Estudos.API.Models;

public class Atividade
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Titulo { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public DateTime Data{ get; set; }

    public bool Concluida { get; set; } = false;

    public int MateriaId { get; set; }

    public Materia? Materia { get; set; }
        
}
