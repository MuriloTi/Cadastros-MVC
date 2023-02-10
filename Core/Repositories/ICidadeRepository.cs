using Core.DTOs;
using Core.Entities;

namespace Core.Repositories
{
    public interface ICidadeRepository
    {
        Task<List<CidadeDTO>> GetAllAsync();
        Task<Cidade> GetByIdAsync(int id);
        Task AddAsync(Cidade cidade);
        Task DeleteAsync(Cidade cidade);
        Task SaveChangesAsync();
    }
}
