using Microsoft.AspNetCore.Mvc;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
