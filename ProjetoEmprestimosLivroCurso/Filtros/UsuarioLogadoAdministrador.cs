using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Filtros
{
    public class UsuarioLogadoAdministrador : ActionFilterAttribute
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
                }
                else if (usuario.Perfil == Enums.PerfilEnum.Administrador)
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
