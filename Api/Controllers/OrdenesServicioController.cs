using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Core.DTOs;
using TallerMecanico.Core.Interfaces;

namespace TallerMecanico.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesServicioController : ControllerBase
{
    private readonly IOrdenServicioService _service;

    public OrdenesServicioController(IOrdenServicioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrdenServicioDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        dto.FechaIngreso = dto.FechaIngreso == default ? DateTime.UtcNow : dto.FechaIngreso;
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrdenServicioDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
