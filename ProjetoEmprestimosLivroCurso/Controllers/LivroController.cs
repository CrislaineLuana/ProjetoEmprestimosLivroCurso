using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;
using ProjetoEmprestimosLivroCurso.Services.LivroService;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        public async Task<ActionResult<List<LivrosModel>>> Index()
        {
            var livros = await _livroInterface.BuscarLivros();
            return View(livros);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Detalhes(int? id)
        {
            if (id != null)
            {
                var livro = await _livroInterface.BuscarLivroPorId(id);
                return View(livro);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
        {

            if (foto != null)
            {
                if (ModelState.IsValid)
                {

                    if (!_livroInterface.VerificaSeJaExisteCadastro(livroCriacaoDto))
                    {

                        TempData["MensagemErro"] = "Código ISBN já cadastrado!";
                        return View(livroCriacaoDto);
                    };

                    var livro = await _livroInterface.Cadastrar(livroCriacaoDto, foto);



                    TempData["MensagemSucesso"] = "Livro Cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["MensagemErro"] = "Verifique os dados preenchidos!";
                    return View(livroCriacaoDto);
                }
            }
            else
            {
                TempData["MensagemErro"] = "Incluir uma imagem de capa!";
                return View(livroCriacaoDto);
            }

        }



    }
}
