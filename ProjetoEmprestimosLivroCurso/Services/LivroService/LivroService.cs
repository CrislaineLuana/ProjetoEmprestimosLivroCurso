using Microsoft.EntityFrameworkCore;
using ProjetoEmprestimosLivroCurso.Data;
using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        private string _caminhoServidor;
        public LivroService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _caminhoServidor = sistema.WebRootPath;
        }

        public async Task<List<LivrosModel>> BuscarLivros()
        {
            try
            {

                var livros = await _context.Livros.ToListAsync();
                return livros;

            }catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
        {
            try
            {
                var codigoUnico = Guid.NewGuid().ToString();
                var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + livroCriacaoDto.ISBN + ".png";

                string caminhoParaSalvarImagens = _caminhoServidor + "\\imagem\\";

                if (!Directory.Exists(caminhoParaSalvarImagens))
                {
                    Directory.CreateDirectory(caminhoParaSalvarImagens);
                }

                using (var stream = System.IO.File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
                {
                    foto.CopyToAsync(stream).Wait();
                }

                var livro = new LivrosModel
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Descricao = livroCriacaoDto.Descricao,
                    Autor = livroCriacaoDto.Autor,
                    Genero = livroCriacaoDto.Genero,
                    QuantidadeEmEstoque = livroCriacaoDto.QuantidadeEmEstoque,
                    AnoPublicacao = livroCriacaoDto.AnoPublicacao,
                    Capa = nomeCaminhoImagem,
                    ISBN = livroCriacaoDto.ISBN

                };


                _context.Add(livro);
                await _context.SaveChangesAsync();

                return livro;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto)
        {
            try
            {
                var livroBanco = _context.Livros.FirstOrDefault(livro => livro.ISBN == livroCriacaoDto.ISBN);
                if (livroBanco != null)
                {
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
