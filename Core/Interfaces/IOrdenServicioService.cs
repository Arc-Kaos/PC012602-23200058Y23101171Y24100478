using TallerMecanico.Core.DTOs;

namespace TallerMecanico.Core.Interfaces;

public interface IOrdenServicioService
{
    Task<IEnumerable<OrdenServicioDto>> GetAllAsync();
    Task<OrdenServicioDto?> GetByIdAsync(int id);
    Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto);
    Task<bool> UpdateAsync(int id, OrdenServicioDto dto);
    Task<bool> DeleteAsync(int id);
}
