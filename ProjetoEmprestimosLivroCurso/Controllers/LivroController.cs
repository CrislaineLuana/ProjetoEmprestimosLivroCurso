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

        [HttpPost]
        public async Task<IActionResult> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
        {

            if (foto != null)
            {
                if (ModelState.IsValid)
                {

                    if (!_livroInterface.VerificaSeJaExisteCadastro(livroCriacaoDto))
                    {

           
                        return View(livroCriacaoDto);
                    };

                    var livro = await _livroInterface.Cadastrar(livroCriacaoDto, foto);

                   



                    return RedirectToAction("Index");
                }

                else
                {

                    return View(livroCriacaoDto);
                }
            }
            else
            {
                return View(livroCriacaoDto);
            }

        }



    }
}
