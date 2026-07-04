using TaskFlowSolid.DTOs;
using TaskFlowSolid.Models;
using TaskFlowSolid.Patterns;
using TaskFlowSolid.Repositories;

namespace TaskFlowSolid.Services;

public class TareaService(ITareaRepository repository, ITareaFactory factory) : ITareaService
{
    public IEnumerable<TareaResponseDto> ObtenerTodas()
    {
        return repository.ObtenerTodas().Select(Mapear);
    }

    public TareaResponseDto? ObtenerPorId(int id)
    {
        var tarea = repository.ObtenerPorId(id);
        return tarea is null ? null : Mapear(tarea);
    }

    public TareaResponseDto Crear(TareaCreateDto dto)
    {
        var tarea = factory.Crear(dto);
        var guardada = repository.Agregar(tarea);
        return Mapear(guardada);
    }

    public bool CambiarEstado(int id, EstadoTarea estado)
    {
        return repository.ActualizarEstado(id, estado);
    }

    private static TareaResponseDto Mapear(Tarea tarea)
    {
        return new TareaResponseDto(
            tarea.Id,
            tarea.Titulo,
            tarea.Descripcion,
            tarea.Materia,
            tarea.FechaEntrega,
            tarea.Estado.ToString(),
            tarea.Prioridad);
    }
}
