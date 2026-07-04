using TaskFlowSolid.DTOs;
using TaskFlowSolid.Models;

namespace TaskFlowSolid.Services;

public interface ITareaService
{
    IEnumerable<TareaResponseDto> ObtenerTodas();
    TareaResponseDto? ObtenerPorId(int id);
    TareaResponseDto Crear(TareaCreateDto dto);
    bool CambiarEstado(int id, EstadoTarea estado);
}
