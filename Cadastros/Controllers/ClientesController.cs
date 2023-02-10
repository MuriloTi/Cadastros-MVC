using Cadastros.Application.InputModels;
using Cadastros.Application.ViewModels;
using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cadastros.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public ClientesController(IClienteRepository clienteRepository, ICidadeRepository cidadeRepository)
        {
            _clienteRepository = clienteRepository;
            _cidadeRepository = cidadeRepository;
        }

        public async Task<IActionResult> Index(string? msg)
        {
            ViewData["msg"] = msg;

            var clientes = await _clienteRepository.GetAllAsync();
            var cidades = await _cidadeRepository.GetAllAsync();

            ViewData["Cidades"] = new SelectList(cidades, "Id", "Nome");

            var viewModel = new ClientesViewModel(clientes, cidades);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Endereco,Bairro,CidadeId,CEP,Telefone")] CreateClienteInputModel inputModel)
        {
            var cidade = await _cidadeRepository.GetByIdAsync(inputModel.CidadeId);
            if (cidade == null)
            {
                return NotFound();
            }
            var cliente = new Cliente(inputModel.Codigo, inputModel.Nome, inputModel.Endereco, inputModel.Bairro, inputModel.CidadeId, inputModel.CEP, inputModel.Telefone);
            await _clienteRepository.AddAsync(cliente);
            return Redirect("~/Clientes?msg=1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Codigo,Nome,Endereco,Bairro,CidadeId,CEP,Telefone")] UpdateClienteInputModel inputModel)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var cidade = await _cidadeRepository.GetByIdAsync(inputModel.CidadeId);
            if (cidade == null)
            {
                return NotFound();
            }
            cliente.Update(inputModel.Codigo, inputModel.Nome, inputModel.Endereco, inputModel.Bairro, inputModel.CidadeId, inputModel.CEP, inputModel.Telefone);
            await _clienteRepository.SaveChangesAsync();
            return Redirect("~/Clientes?msg=2");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteRepository.DeleteAsync(cliente);
            return Redirect("~/Clientes?msg=3");
        }

        public async Task<IActionResult> Relatorio()
        {
            var clientes = await _clienteRepository.GetAllAsync();

            var cidades = from c in clientes
                          group c by new { c.CidadeId, c.Cidade, c.UF }
                          into g
                          select new RelatorioClientesViewModel.CidadeItem
                          {
                              Cidade = g.Key.Cidade,
                              UF = g.Key.UF,
                              Clientes = g.ToList()
                          };

            var viewModel = new RelatorioClientesViewModel(cidades.OrderBy(c => c.Cidade).ToList());
            return View(viewModel);
        }
    }
}
