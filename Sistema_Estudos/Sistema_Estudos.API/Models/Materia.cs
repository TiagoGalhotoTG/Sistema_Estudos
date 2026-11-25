using System.ComponentModel.DataAnnotations;

namespace Sistema_Estudos.API.Models;
public class Materia
{
    public int Id { get; set;}

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public ICollection<Atividade>? Atividade { get; set; }
    = new List<Atividade>();

}

