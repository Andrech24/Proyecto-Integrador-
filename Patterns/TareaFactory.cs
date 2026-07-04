using TaskFlowSolid.DTOs;
using TaskFlowSolid.Models;

namespace TaskFlowSolid.Patterns;

public class TareaFactory(IPrioridadStrategy prioridadStrategy) : ITareaFactory
{
    public Tarea Crear(TareaCreateDto dto)
    {
        return new Tarea
        {
            Titulo = dto.Titulo.Trim(),
            Descripcion = dto.Descripcion.Trim(),
            Materia = dto.Materia.Trim(),
            FechaEntrega = dto.FechaEntrega.Date,
            Estado = EstadoTarea.Pendiente,
            Prioridad = prioridadStrategy.Calcular(dto)
        };
    }
}
