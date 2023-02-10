using Cadastros.Application.InputModels;
using Cadastros.Application.ViewModels;
using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadesController(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public async Task<IActionResult> Index(string? msg)
        {
            ViewData["msg"] = msg;

            var cidades = await _cidadeRepository.GetAllAsync();

            var viewModel = new CidadesViewModel(cidades);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,UF")] CreateCidadeInputModel inputModel)
        {
            var cidade = new Cidade(inputModel.Codigo, inputModel.Nome, inputModel.UF);
            await _cidadeRepository.AddAsync(cidade);
            return Redirect("~/Cidades?msg=1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Codigo,Nome,UF")] UpdateCidadeInputModel inputModel)
        {
            var cidade = await _cidadeRepository.GetByIdAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            cidade.Update(inputModel.Codigo, inputModel.Nome, inputModel.UF);
            await _cidadeRepository.SaveChangesAsync();
            return Redirect("~/Cidades?msg=2");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cidade = await _cidadeRepository.GetByIdAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            if (cidade.Clientes.Any())
            {
                return Redirect("~/Cidades?msg=3");
            }
            await _cidadeRepository.DeleteAsync(cidade);
            return Redirect("~/Cidades?msg=4");
        }
    }
}
