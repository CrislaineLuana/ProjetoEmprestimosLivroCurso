using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Services.SessaoService;
using System.Diagnostics;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessaoInterface _sessaoInterface;

        public HomeController(ISessaoInterface sessaoInterface)
        {
            _sessaoInterface = sessaoInterface;
        }
        public IActionResult Index()
        {

            var usuarioSessao = _sessaoInterface.BuscarSessao();
            if(usuarioSessao != null)
            {
                ViewBag.LayoutPagina = "_Layout";
            }
            else
            {
                ViewBag.LayoutPagina = "_LayoutDeslogada";
            }

            return View();
        }

       

        
    }
}
