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

        [HttpGet]
        public ActionResult Index()
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


        [HttpGet]
        public ActionResult Login()
        {
            if(_sessaoInterface.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        
    }
}
