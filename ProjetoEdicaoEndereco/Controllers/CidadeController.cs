using Microsoft.AspNetCore.Mvc;
using ProjetoEdicaoEndereco.Data;

namespace SistemaCadastro.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ProjetoEdicaoEnderecoContext _context;

        public CidadeController(ProjetoEdicaoEnderecoContext context)
        {
            _context = context;
        }

        [HttpGet("api/cidades/{estadoId}")]
        public IActionResult GetCidadesPorEstado(int estadoId)
        {
            try
            {
                var cidades = _context.Cidade
                    .Where(c => c.EstadosId == estadoId)
                    .ToList();

                return Ok(cidades);
            }
            catch (Exception ex)
            {
                // Registre o erro em um log (opcional)
                Console.WriteLine($"Erro ao buscar cidades por estado: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}