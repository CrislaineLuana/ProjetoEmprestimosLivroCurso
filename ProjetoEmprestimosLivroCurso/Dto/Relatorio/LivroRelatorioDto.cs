using ProjetoEmprestimosLivroCurso.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEmprestimosLivroCurso.Dto.Relatorio
{
    public class LivroRelatorioDto
    {

        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string Capa { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;
 
        public string Autor { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;
  
        public int AnoPublicacao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
    }
}
