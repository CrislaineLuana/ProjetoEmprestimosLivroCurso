using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.EmprestimoService
{
    public interface IEmprestimoInterface
    {
        Task<RespostaModel<EmprestimoModel>> Emprestar(int livroId);
        Task<List<EmprestimoModel>> BuscarEmprestimosFiltro(UsuarioModel usuarioSessao, string pesquisar);
        Task<List<EmprestimoModel>> BuscarEmprestimos(UsuarioModel usuarioSessao);

        Task<EmprestimoModel> Devolver(int id);
    }
}
