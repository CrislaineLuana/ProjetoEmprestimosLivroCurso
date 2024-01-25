using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<List<LivrosModel>> BuscarLivros();
        Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto);
        bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto);
        Task<LivrosModel> BuscarLivroPorId(int? id);

    }
}
