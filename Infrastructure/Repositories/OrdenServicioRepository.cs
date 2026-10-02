using Microsoft.EntityFrameworkCore;
using TallerMecanico.Core.DTOs;
using TallerMecanico.Core.Interfaces;
using TallerMecanico.Data;
using TallerMecanico.Models;

namespace TallerMecanico.Infrastructure.Repositories;

public class OrdenServicioRepository : IOrdenServicioRepository
{
    private readonly TallerDbContext _context;

    public OrdenServicioRepository(TallerDbContext context)
    {
        _context = context;
    }

    private static OrdenServicioDto ToDto(OrdenServicio e) => new OrdenServicioDto
    {
        Id = e.Id,
        FechaIngreso = e.FechaIngreso,
        DescripcionProblema = e.DescripcionProblema,
        CostoEstimado = e.CostoEstimado,
        Estado = e.Estado,
        VehiculoId = e.VehiculoId,
        TipoServicioId = e.TipoServicioId
    };

    private static OrdenServicio ToEntity(OrdenServicioDto d) => new OrdenServicio
    {
        Id = d.Id,
        FechaIngreso = d.FechaIngreso,
        DescripcionProblema = d.DescripcionProblema,
        CostoEstimado = d.CostoEstimado,
        Estado = d.Estado,
        VehiculoId = d.VehiculoId,
        TipoServicioId = d.TipoServicioId
    };

    public async Task<OrdenServicioDto> AddAsync(OrdenServicioDto orden)
    {
        var entity = ToEntity(orden);
        _context.OrdenesServicio.Add(entity);
        await _context.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.OrdenesServicio.FindAsync(id);
        if (entity is null) return;
        _context.OrdenesServicio.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrdenServicioDto>> GetAllAsync()
    {
        var list = await _context.OrdenesServicio.AsNoTracking().ToListAsync();
        return list.Select(ToDto);
    }

    public async Task<OrdenServicioDto?> GetByIdAsync(int id)
    {
        var e = await _context.OrdenesServicio.FindAsync(id);
        return e is null ? null : ToDto(e);
    }

    public async Task UpdateAsync(OrdenServicioDto orden)
    {
        var entity = ToEntity(orden);
        _context.OrdenesServicio.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.OrdenesServicio.AnyAsync(o => o.Id == id);
    }
}
