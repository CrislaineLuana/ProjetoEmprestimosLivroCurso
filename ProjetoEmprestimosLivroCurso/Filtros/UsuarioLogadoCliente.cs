using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Filtros
{
    public class UsuarioLogadoCliente : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("SessaoUsuario");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {

                    {"controller", "Home" },
                    {"Action", "Login" }

                });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {

                    {"controller", "Home" },
                    {"Action", "Login" }

                 });
                }else if (usuario.Perfil == Enums.PerfilEnum.Cliente)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {

                    {"controller", "Home" },
                    {"Action", "Index" }

                });
                }

            }




            base.OnActionExecuting(context);
        }
    }
}
