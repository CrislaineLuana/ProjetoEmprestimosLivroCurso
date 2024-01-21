using Microsoft.AspNetCore.Mvc;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
