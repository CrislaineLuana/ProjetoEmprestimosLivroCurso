using AutoMapper;
using ProjetoEmprestimosLivroCurso.Dto;
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
        }
    }
}
