using Microsoft.AspNetCore.Mvc;
using ProjetoEdicaoEndereco.Repositories;

namespace ProjetoEdicaoEndereco.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIndividuoRepositorio _context;

        public LoginController(IIndividuoRepositorio individuoRepositorio)
        {
            _context = individuoRepositorio;
        }

        [HttpPost]
        public IActionResult Index(string documento, string placa)
        {
            var individuo = _context.ObterPorDocumentoEPlaca(documento, placa);
            
            Console.WriteLine(individuo);
            
            if (individuo != null)
            {
                HttpContext.Session.SetInt32("IndividuoId", individuo.Id);
                return RedirectToAction("Detalhes", "Individuo");
            }
            else
            {
                ViewBag.MensagemErro = "Documento ou placa inválidos.";
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
