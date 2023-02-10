using Core.DTOs;
using Core.Entities;

namespace Core.Repositories
{
    public interface IClienteRepository
    {
        Task<List<ClienteDTO>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
        Task SaveChangesAsync();
    }
}
