using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<List<LivroModel>> BuscarLivros();
        Task<LivroModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto);
        bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto);
        Task<LivroModel> BuscarLivroPorId(int? id);
        Task<LivroModel> Editar(LivroEdicaoDto livroEdicaoDto, IFormFile foto);

    }
}
