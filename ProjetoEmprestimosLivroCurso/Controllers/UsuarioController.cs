using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Enums;
using ProjetoEmprestimosLivroCurso.Services.UsuarioService;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<ActionResult> Index(int? id)
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios(id);
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id)
        {
            //  UsuarioRegisterDto usuarioRegisterDto = new UsuarioRegisterDto();

            ViewBag.Perfil = PerfilEnum.Administrador;

            if (id != null)
            {
                //usuarioRegisterDto = new UsuarioRegisterDto();

                ViewBag.Perfil = PerfilEnum.Cliente;
            }



            return View();
        }
    }
}
