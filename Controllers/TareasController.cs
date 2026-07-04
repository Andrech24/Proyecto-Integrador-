using Microsoft.AspNetCore.Mvc;
using TaskFlowSolid.DTOs;
using TaskFlowSolid.Services;

namespace TaskFlowSolid.Controllers;

public class TareasController(ITareaService tareaService) : Controller
{
    public IActionResult Index()
    {
        return View(tareaService.ObtenerTodas());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new TareaCreateDto { FechaEntrega = DateTime.Today.AddDays(1) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TareaCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        tareaService.Crear(dto);
        return RedirectToAction(nameof(Index));
    }
}
