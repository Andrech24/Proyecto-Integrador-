using TaskFlowSolid.Models;

namespace TaskFlowSolid.Repositories;

public class InMemoryTareaRepository : ITareaRepository
{
    private readonly List<Tarea> _tareas =
    [
        new()
        {
            Id = 1,
            Titulo = "Informe de bases de datos",
            Descripcion = "Preparar consultas y capturas de evidencia.",
            Materia = "Ingenieria Web",
            FechaEntrega = DateTime.Today.AddDays(2),
            Estado = EstadoTarea.Pendiente,
            Prioridad = 5
        },
        new()
        {
            Id = 2,
            Titulo = "Practica de patrones",
            Descripcion = "Documentar Strategy y Factory Method.",
            Materia = "Arquitectura de Software",
            FechaEntrega = DateTime.Today.AddDays(6),
            Estado = EstadoTarea.EnProgreso,
            Prioridad = 3
        }
    ];

    public IEnumerable<Tarea> ObtenerTodas()
    {
        return _tareas.OrderByDescending(t => t.Prioridad).ThenBy(t => t.FechaEntrega);
    }

    public Tarea? ObtenerPorId(int id)
    {
        return _tareas.FirstOrDefault(t => t.Id == id);
    }

    public Tarea Agregar(Tarea tarea)
    {
        tarea.Id = _tareas.Count == 0 ? 1 : _tareas.Max(t => t.Id) + 1;
        _tareas.Add(tarea);
        return tarea;
    }

    public bool ActualizarEstado(int id, EstadoTarea estado)
    {
        var tarea = ObtenerPorId(id);
        if (tarea is null)
        {
            return false;
        }

        tarea.Estado = estado;
        return true;
    }
}
