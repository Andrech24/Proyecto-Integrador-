using System.ComponentModel.DataAnnotations;

namespace TaskFlowSolid.Models;

public class Tarea
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(300)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    public string Materia { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime FechaEntrega { get; set; }

    public EstadoTarea Estado { get; set; }

    public int Prioridad { get; set; }
}
