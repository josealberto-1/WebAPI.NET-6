using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCorePlantillas.Models;
using System.Linq;
using System.Threading.Tasks;
using WebApiPlantillas.Services;

[Route("api/[controller]")]
[ApiController]
public class PlantillasController : ControllerBase
{
    private readonly IPlantillaService _plantillaService;

    public PlantillasController(IPlantillaService plantillaService)
    {
        _plantillaService = plantillaService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Plantilla>> GetPlantillas()
    {
        var plantillas = _plantillaService.GetPlantillas();
        return Ok(plantillas);
    }

    [HttpGet("{id}")]
    public ActionResult<Plantilla> GetPlantilla(int id)
    {
        var plantilla = _plantillaService.GetPlantillaById(id);
        if (plantilla == null)
        {
            return NotFound();
        }
        return Ok(plantilla);
    }

    [HttpPost]
    public ActionResult<Plantilla> CrearPlantilla(Plantilla plantilla)
    {
        var nuevaPlantilla = _plantillaService.CrearPlantilla(plantilla);
        return CreatedAtAction(nameof(GetPlantilla), new { id = nuevaPlantilla.Id }, nuevaPlantilla);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarPlantilla(int id, Plantilla plantilla)
    {
        if (id != plantilla.Id)
        {
            return BadRequest();
        }
        _plantillaService.ActualizarPlantilla(plantilla);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarPlantilla(int id)
    {
        _plantillaService.EliminarPlantilla(id);
        return NoContent();
    }

}