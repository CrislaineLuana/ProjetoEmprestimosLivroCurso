using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<List<LivrosModel>> BuscarLivros();

    }
}
