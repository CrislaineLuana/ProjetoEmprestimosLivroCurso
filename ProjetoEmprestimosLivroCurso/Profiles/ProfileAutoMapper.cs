using AutoMapper;
using ProjetoEmprestimosLivroCurso.Dto.Endereco;
using ProjetoEmprestimosLivroCurso.Dto.Livro;
using ProjetoEmprestimosLivroCurso.Dto.Relatorio;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Profiles
{
    public class ProfileAutoMapper : Profile
    {

        public ProfileAutoMapper()
        {

            CreateMap<LivroCriacaoDto, LivroModel>();
            CreateMap<LivroModel, LivroEdicaoDto>();
            CreateMap<LivroEdicaoDto,LivroModel >();
            CreateMap<EnderecoModel, EnderecoEditarDto>();
            CreateMap<EnderecoEditarDto, EnderecoModel>();
            CreateMap<LivroModel, LivroRelatorioDto>();
            CreateMap<UsuarioModel, UsuarioRelatorioDto>();
            CreateMap<EmprestimoModel, EmprestimoRelatorioDto>();
        }
    }
}
