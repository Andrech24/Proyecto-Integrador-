using System.ComponentModel.DataAnnotations;

namespace TaskFlowSolid.DTOs;

public class TareaCreateDto
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(300)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    public string Materia { get; set; } = string.Empty;

    [Required]
    public DateTime FechaEntrega { get; set; }
}
