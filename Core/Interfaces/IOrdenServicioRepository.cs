using TallerMecanico.Core.DTOs;

namespace TallerMecanico.Core.Interfaces;

public interface IOrdenServicioRepository
{
    Task<IEnumerable<OrdenServicioDto>> GetAllAsync();
    Task<OrdenServicioDto?> GetByIdAsync(int id);
    Task<OrdenServicioDto> AddAsync(OrdenServicioDto orden);
    Task UpdateAsync(OrdenServicioDto orden);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
