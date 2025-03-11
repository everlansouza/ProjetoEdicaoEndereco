using Microsoft.AspNetCore.Mvc;
using ProjetoEdicaoEndereco.Repositories;

namespace ProjetoEdicaoEndereco.Controllers
{
    public class IndividuoController : Controller
    {
        private readonly IIndividuoRepositorio _individuoRepositorio;

        public IndividuoController(IIndividuoRepositorio individuoRepositorio)
        {
            _individuoRepositorio = individuoRepositorio;
        }

        public IActionResult Detalhes()
        {
            if (HttpContext.Session.GetInt32("IndividuoId") == null)
            {
                return RedirectToAction("NotFound", "Login");
            }

            int individuoId = (int)HttpContext.Session.GetInt32("IndividuoId");

            var individuo = _individuoRepositorio.ObterPorId(individuoId);

            return View(individuo);
        }
    }
}
