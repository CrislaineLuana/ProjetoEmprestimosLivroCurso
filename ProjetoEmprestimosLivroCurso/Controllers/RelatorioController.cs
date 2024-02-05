using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimosLivroCurso.Dto.Relatorio;
using ProjetoEmprestimosLivroCurso.Models;
using ProjetoEmprestimosLivroCurso.Services.EmprestimoService;
using ProjetoEmprestimosLivroCurso.Services.LivroService;
using ProjetoEmprestimosLivroCurso.Services.RelatorioService;
using ProjetoEmprestimosLivroCurso.Services.SessaoService;
using ProjetoEmprestimosLivroCurso.Services.UsuarioService;
using System.Data;

namespace ProjetoEmprestimosLivroCurso.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ISessaoInterface _sessaoInterface;
        private readonly ILivroInterface _livroInterface;
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly IEmprestimoInterface _emprestimo;
        private readonly IRelatorioInterface _relatorioInterface;
        private readonly IMapper _mapper;

        public RelatorioController(ISessaoInterface sessaoInterface, 
                                ILivroInterface livroInterface, 
                                IUsuarioInterface usuarioInterface,
                                IEmprestimoInterface emprestimo, 
                                IRelatorioInterface relatorioInterface, 
                                IMapper mapper)
        {
            _sessaoInterface = sessaoInterface;
            _livroInterface = livroInterface;
            _usuarioInterface = usuarioInterface;
            _emprestimo = emprestimo;
            _relatorioInterface = relatorioInterface;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Gerar(int id)
        {

            var tabela = new DataTable();

            switch (id)
            {
                case 1:
                    List<LivroModel> livros = await _livroInterface.BuscarLivros();
                    List<LivroRelatorioDto> dadosLivros = _mapper.Map<List<LivroRelatorioDto>>(livros);
                    tabela = _relatorioInterface.ColetarDados(dadosLivros, id);
                break;
            }



            using(XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(tabela, "Dados");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Dados.xls");
                }
            }

            
        }
    }
}
