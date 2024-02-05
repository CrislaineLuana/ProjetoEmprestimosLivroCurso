﻿using AutoMapper;
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


    }
}
