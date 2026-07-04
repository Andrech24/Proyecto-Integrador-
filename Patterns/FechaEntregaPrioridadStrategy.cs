using TaskFlowSolid.DTOs;

namespace TaskFlowSolid.Patterns;

public class FechaEntregaPrioridadStrategy : IPrioridadStrategy
{
    public int Calcular(TareaCreateDto dto)
    {
        var dias = (dto.FechaEntrega.Date - DateTime.Today).TotalDays;

        return dias switch
        {
            <= 1 => 5,
            <= 3 => 4,
            <= 7 => 3,
            <= 14 => 2,
            _ => 1
        };
    }
}
