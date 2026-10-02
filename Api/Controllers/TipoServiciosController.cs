using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Data;
using TallerMecanico.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoServiciosController : ControllerBase
{
    private readonly TallerDbContext _context;

    public TipoServiciosController(TallerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoServicio>>> GetTipoServicios()
    {
        var lista = await _context.TipoServicios.ToListAsync();
        return Ok(lista);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TipoServicio>> GetTipoServicio(int id)
    {
        var tipo = await _context.TipoServicios.FindAsync(id);
        if (tipo == null) return NotFound();
        return Ok(tipo);
    }

    [HttpPost]
    public async Task<ActionResult<TipoServicio>> CreateTipoServicio(TipoServicio tipoServicio)
    {
        _context.TipoServicios.Add(tipoServicio);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipoServicio), new { id = tipoServicio.Id }, tipoServicio);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTipoServicio(int id, TipoServicio tipoServicio)
    {
        if (id != tipoServicio.Id) return BadRequest();

        _context.Entry(tipoServicio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.TipoServicios.AnyAsync(t => t.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTipoServicio(int id)
    {
        var tipo = await _context.TipoServicios.FindAsync(id);
        if (tipo == null) return NotFound();

        _context.TipoServicios.Remove(tipo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
