using Core.DTOs;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly CadastrosDbContext _cadastrosDbContext;

        public CidadeRepository(CadastrosDbContext cadastrosDbContext)
        {
            _cadastrosDbContext = cadastrosDbContext;
        }

        public async Task AddAsync(Cidade cidade)
        {
            await _cadastrosDbContext.Cidades.AddAsync(cidade);
            await _cadastrosDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cidade cidade)
        {
            _cadastrosDbContext.Cidades.Remove(cidade);
            await _cadastrosDbContext.SaveChangesAsync();
        }

        public async Task<List<CidadeDTO>> GetAllAsync()
        {
            var cidades = await _cadastrosDbContext.Cidades
                .Include(c => c.Clientes)
                .ToListAsync();
            var cidadesDTO = new List<CidadeDTO>();
            foreach (var cidade in cidades)
            {
                cidadesDTO.Add(new CidadeDTO(cidade));
            }
            return cidadesDTO;
        }

        public async Task<Cidade> GetByIdAsync(int id)
        {
            var cidade = await _cadastrosDbContext.Cidades
                .Include(c => c.Clientes)
                .SingleOrDefaultAsync(c => c.Id == id);
            return cidade;
        }

        public async Task SaveChangesAsync()
        {
            await _cadastrosDbContext.SaveChangesAsync();
        }
    }
}
