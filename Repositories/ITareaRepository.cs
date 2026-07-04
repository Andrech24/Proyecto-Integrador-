using TaskFlowSolid.Models;

namespace TaskFlowSolid.Repositories;

public interface ITareaRepository
{
    IEnumerable<Tarea> ObtenerTodas();
    Tarea? ObtenerPorId(int id);
    Tarea Agregar(Tarea tarea);
    bool ActualizarEstado(int id, EstadoTarea estado);
}
