using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
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
                case 2:
                    List<UsuarioModel> clientes = await _usuarioInterface.BuscarUsuarios(0);
                    List<UsuarioRelatorioDto> dadosClientes = new List<UsuarioRelatorioDto>();

                    foreach (var cliente in  clientes)
                    {
                        dadosClientes.Add(
                            new UsuarioRelatorioDto
                            {
                                Id = cliente.Id,
                                NomeCompleto = cliente.NomeCompleto,
                                Usuario = cliente.Usuario,
                                Email = cliente.Email,
                                Situacao = cliente.Situacao.ToString(),
                                Perfil = cliente.Perfil.ToString(),
                                Turno = cliente.Turno.ToString(),
                                Logradouro = cliente.Endereco.Logradouro,
                                Bairro = cliente.Endereco.Bairro,
                                Numero = cliente.Endereco.Numero,
                                CEP = cliente.Endereco.CEP,
                                Estado = cliente.Endereco.Estado,
                                Complemento = cliente.Endereco.Complemento,
                                DataCadastro = cliente.DataCadastro,
                                DataAlteracao = cliente.DataAlteracao
                            }

                     );
                    }

                    tabela = _relatorioInterface.ColetarDados(dadosClientes, id);

                break;
                case 3:
                    List<UsuarioModel> funcionarios = await _usuarioInterface.BuscarUsuarios(null);
                    List<UsuarioRelatorioDto> dadosFuncionarios = new List<UsuarioRelatorioDto>();

                    foreach (var funcionario in funcionarios)
                    {
                        dadosFuncionarios.Add(
                            new UsuarioRelatorioDto
                            {
                                Id = funcionario.Id,
                                NomeCompleto = funcionario.NomeCompleto,
                                Usuario = funcionario.Usuario,
                                Email = funcionario.Email,
                                Situacao = funcionario.Situacao.ToString(),
                                Perfil = funcionario.Perfil.ToString(),
                                Turno = funcionario.Turno.ToString(),
                                Logradouro = funcionario.Endereco.Logradouro,
                                Bairro = funcionario.Endereco.Bairro,
                                Numero = funcionario.Endereco.Numero,
                                CEP = funcionario.Endereco.CEP,
                                Estado = funcionario.Endereco.Estado,
                                Complemento = funcionario.Endereco.Complemento,
                                DataCadastro = funcionario.DataCadastro,
                                DataAlteracao = funcionario.DataAlteracao
                            }

                     );
                    }

                    tabela = _relatorioInterface.ColetarDados(dadosFuncionarios, id);

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
