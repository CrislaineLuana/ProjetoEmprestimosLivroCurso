using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.UsuarioService
{
    public interface IUsuarioInterface
    {
        Task<List<UsuarioModel>> BuscarUsuarios(int? id);
    }
}
