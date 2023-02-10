using Core.DTOs;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastrosDbContext _cadastrosDbContext;

        public ClienteRepository(CadastrosDbContext cadastrosDbContext)
        {
            _cadastrosDbContext = cadastrosDbContext;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _cadastrosDbContext.Clientes.AddAsync(cliente);
            await _cadastrosDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _cadastrosDbContext.Clientes.Remove(cliente);
            await _cadastrosDbContext.SaveChangesAsync();
        }

        public async Task<List<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _cadastrosDbContext.Clientes
                .Include(c => c.Cidade)
                .ToListAsync();
            var clientesDTO = new List<ClienteDTO>();
            foreach (var cliente in clientes)
            {
                clientesDTO.Add(new ClienteDTO(cliente, cliente.Cidade));
            }
            return clientesDTO;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var cliente = await _cadastrosDbContext.Clientes
                .SingleOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        public async Task SaveChangesAsync()
        {
            await _cadastrosDbContext.SaveChangesAsync();
        }
    }
}
