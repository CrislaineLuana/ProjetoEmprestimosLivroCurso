using AutoMapper;
using Newtonsoft.Json;
using ProjetoEmprestimosLivroCurso.Dto.Relatorio;
using ProjetoEmprestimosLivroCurso.Enums;
using System.Data;

namespace ProjetoEmprestimosLivroCurso.Services.RelatorioService
{
    public class RelatorioService : IRelatorioInterface
    {
        private readonly IMapper _mapper;

        public RelatorioService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DataTable ColetarDados<T>(List<T> dados, int idRelatorio)
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = Enum.GetName(typeof(RelatorioEnum), idRelatorio);


            var colunas = dados.First().GetType().GetProperties();


            foreach (var coluna in colunas)
            {
                dataTable.Columns.Add(coluna.Name, coluna.PropertyType);
            }



            switch (idRelatorio)
            {
                case 1:
                    var dadosLivro = JsonConvert.SerializeObject(dados);
                    var dadosLivroModel = JsonConvert.DeserializeObject<List<LivroRelatorioDto>>(dadosLivro);
                    if(dadosLivroModel != null)
                    {
                        return ExportarLivro(dataTable, dadosLivroModel);
                    }

                break;
                case 2:

                    var dadosCliente = JsonConvert.SerializeObject(dados);
                    var dadosClientesModel = JsonConvert.DeserializeObject<List<UsuarioRelatorioDto>>(dadosCliente);
                    if(dadosClientesModel != null)
                    {
                        return ExportarUsuario(dataTable, dadosClientesModel);
                    }

                    break;
                case 3:

                    var dadosFuncionario = JsonConvert.SerializeObject(dados);
                    var dadosFuncionarioModel = JsonConvert.DeserializeObject<List<UsuarioRelatorioDto>>(dadosFuncionario);
                    if (dadosFuncionarioModel != null)
                    {
                        return ExportarUsuario(dataTable, dadosFuncionarioModel);
                    }


                    break;
                case 4:
                    var dadosEmprestimo = JsonConvert.SerializeObject(dados);
                    var dadosEmprestimoModel = JsonConvert.DeserializeObject<List<EmprestimoRelatorioDto>>(dadosEmprestimo);
                    if (dadosEmprestimoModel != null)
                    {
                        return ExportarEmprestimo(dataTable, dadosEmprestimoModel);
                    }
                    break;
                case 5:
                    var dadosEmprestimoPendentes = JsonConvert.SerializeObject(dados);
                    var dadosEmprestimoPendentesModel = JsonConvert.DeserializeObject<List<EmprestimoRelatorioDto>>(dadosEmprestimoPendentes);
                    if (dadosEmprestimoPendentesModel != null)
                    {
                        return ExportarEmprestimoPendentes(dataTable, dadosEmprestimoPendentesModel);
                    }
                    break;

                    break;
            }

            return new DataTable();
        }




        public DataTable ExportarLivro(DataTable data, List<LivroRelatorioDto> dados)
        {
            foreach(var dado in dados)
            {
                data.Rows.Add(dado.Id, dado.Titulo, dado.Descricao, dado.Capa, dado.ISBN, dado.Autor, dado.Genero, dado.AnoPublicacao, dado.QuantidadeEmEstoque, dado.DataDeCadastro, dado.DataDeAlteracao);
            }

            return data;
        }


        public DataTable ExportarUsuario(DataTable data, List<UsuarioRelatorioDto> dados)
        {
            foreach (var dado in dados)
            {
                data.Rows.Add(dado.Id, dado.NomeCompleto, dado.Usuario, dado.Email, dado.Situacao == "True" ? "Ativo" : "Inativo", dado.Perfil, dado.Turno,dado.Logradouro, dado.Bairro, dado.Numero, dado.CEP, dado.Estado, dado.Complemento, dado.DataCadastro, dado.DataAlteracao);
            }

            return data;
        }


        public DataTable ExportarEmprestimo(DataTable data, List<EmprestimoRelatorioDto> dados)
        {
            foreach (var dado in dados)
            {
                data.Rows.Add(dado.Id, dado.UsuarioId, dado.NomeCompleto, dado.Usuario, dado.LivroId, dado.Titulo, dado.ISBN, dado.DataEmprestimo, dado.DataDevolucao);
            }

            return data;
        }

        public DataTable ExportarEmprestimoPendentes(DataTable data, List<EmprestimoRelatorioDto> dados)
        {
            foreach (var dado in dados)
            {
                data.Rows.Add(dado.Id, dado.UsuarioId, dado.NomeCompleto, dado.Usuario, dado.LivroId, dado.Titulo, dado.ISBN, dado.DataEmprestimo);
            }

            return data;
        }


    }
}
