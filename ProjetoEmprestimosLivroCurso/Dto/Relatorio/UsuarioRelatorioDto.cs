using ProjetoEmprestimosLivroCurso.Enums;
using ProjetoEmprestimosLivroCurso.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEmprestimosLivroCurso.Dto.Relatorio
{
    public class UsuarioRelatorioDto
    {
     
        public int Id { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;
  
        public string Usuario { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool Situacao { get; set; } = true;
      
        public string Perfil { get; set; }

        public string Turno { get; set; }

        public string Logradouro { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string CEP { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
