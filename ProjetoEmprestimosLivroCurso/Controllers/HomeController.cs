using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Dto.Home;
using ProjetoEmprestimosLivroCurso.Services.HomeService;
using ProjetoEmprestimosLivroCurso.Services.SessaoService;
using System.Diagnostics;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessaoInterface _sessaoInterface;
        private readonly IHomeInterface _homeInterface;

        public HomeController(ISessaoInterface sessaoInterface, IHomeInterface homeInterface)
        {
            _sessaoInterface = sessaoInterface;
            _homeInterface = homeInterface;
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

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var login = await _homeInterface.RealizarLogin(loginDto);

                if (login.Status == false)
                {
                    TempData["MensagemErro"] = login.Mensagem;
                    return View(login.Dados);
                }

                if(login.Dados.Situacao == false)
                {
                    TempData["MensagemErro"] = "Procure o suporte para verificar o status da sua conta!";
                    return View("Login");   
                }


                _sessaoInterface.CriarSessao(login.Dados);
                TempData["MensagemSucesso"] = login.Mensagem;

                return RedirectToAction("Index");

            }
            else
            {
                return View(loginDto);
            }
        }

        
    }
}
