using TaskFlowSolid.DTOs;

namespace TaskFlowSolid.Patterns;

public interface IPrioridadStrategy
{
    int Calcular(TareaCreateDto dto);
}
