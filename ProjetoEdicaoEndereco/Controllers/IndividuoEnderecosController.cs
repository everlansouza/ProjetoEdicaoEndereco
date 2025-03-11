using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdicaoEndereco.Data;
using ProjetoEdicaoEndereco.Repositories;
using SistemaAtulizarEndereco.Models;

namespace ProjetoEdicaoEndereco.Controllers
{
    public class IndividuoEnderecosController : Controller
    {
        private readonly ProjetoEdicaoEnderecoContext _context;
        private readonly IIndividuoRepositorio _individuoRepositorio;

        public IndividuoEnderecosController(IIndividuoRepositorio individuoRepositorio, ProjetoEdicaoEnderecoContext context)
        {
            _individuoRepositorio = individuoRepositorio;
            _context = context;
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var endereco = _context
                    .IndividuoEndereco
                    .Include(e => e.Cidade)
                    .ThenInclude(c => c.Estado)
                    .FirstOrDefault(e => e.Id == id);


                if (endereco == null)
                {
                    return NotFound();
                }

                ViewBag.Estados = _context.Estado.ToList();

                ViewBag.Cidades = _context.Cidade
                        .Where(c => c.EstadosId == endereco.Cidade.EstadosId)
                        .ToList();

                return View(endereco);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir página de edição de endereço: {ex.Message}");

                return RedirectToAction("NotFound", "Login");
            }
        }

        [HttpPost]
        public IActionResult Editar(IndividuoEndereco endereco)
        {
            try
            {
                _context.Entry(endereco).State = EntityState.Modified;
                _context.SaveChanges();

                Console.WriteLine("Endereço atualizado com sucesso!");
                return RedirectToAction("Detalhes", "Individuo", new { id = endereco.IndividuoId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar endereço: {ex.Message}");
                return RedirectToAction("NotFound", "Login");
            }
        }

    }
}
