using TallerMecanico.Core.DTOs;
using TallerMecanico.Core.Interfaces;
namespace TallerMecanico.Infrastructure.Services;

public class OrdenServicioService : IOrdenServicioService
{
    private readonly IOrdenServicioRepository _repository;

    public OrdenServicioService(IOrdenServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto)
    {
        return await _repository.AddAsync(dto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _repository.ExistsAsync(id)) return false;
        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<OrdenServicioDto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OrdenServicioDto?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, OrdenServicioDto dto)
    {
        if (!await _repository.ExistsAsync(id)) return false;
        dto.Id = id;
        await _repository.UpdateAsync(dto);
        return true;
    }
}
