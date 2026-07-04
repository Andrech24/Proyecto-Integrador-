using TaskFlowSolid.DTOs;
using TaskFlowSolid.Models;

namespace TaskFlowSolid.Patterns;

public interface ITareaFactory
{
    Tarea Crear(TareaCreateDto dto);
}
