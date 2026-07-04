using Microsoft.AspNetCore.Mvc;
using TaskFlowSolid.DTOs;
using TaskFlowSolid.Models;
using TaskFlowSolid.Services;

namespace TaskFlowSolid.Controllers.Api;

[ApiController]
[Route("api/tareas")]
public class TareasApiController(ITareaService tareaService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<TareaResponseDto>> Get()
    {
        return Ok(tareaService.ObtenerTodas());
    }

    [HttpGet("{id:int}")]
    public ActionResult<TareaResponseDto> GetById(int id)
    {
        var tarea = tareaService.ObtenerPorId(id);
        return tarea is null ? NotFound() : Ok(tarea);
    }

    [HttpPost]
    public ActionResult<TareaResponseDto> Post(TareaCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var creada = tareaService.Crear(dto);
        return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
    }

    [HttpPatch("{id:int}/estado")]
    public IActionResult PatchEstado(int id, [FromBody] EstadoRequest request)
    {
        if (!Enum.TryParse<EstadoTarea>(request.Estado, true, out var estado))
        {
            return BadRequest(new { mensaje = "Estado no valido. Use Pendiente, EnProgreso o Completada." });
        }

        return tareaService.CambiarEstado(id, estado) ? NoContent() : NotFound();
    }

    public record EstadoRequest(string Estado);
}
