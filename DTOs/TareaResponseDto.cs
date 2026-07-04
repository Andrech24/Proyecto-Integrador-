namespace TaskFlowSolid.DTOs;

public record TareaResponseDto(
    int Id,
    string Titulo,
    string Descripcion,
    string Materia,
    DateTime FechaEntrega,
    string Estado,
    int Prioridad);
