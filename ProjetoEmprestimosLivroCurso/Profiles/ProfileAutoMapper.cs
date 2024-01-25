using AutoMapper;
using ProjetoEmprestimosLivroCurso.Dto;
using ProjetoEmprestimosLivroCurso.Models;

namespace ProjetoEmprestimosLivroCurso.Profiles
{
    public class ProfileAutoMapper : Profile
    {

        public ProfileAutoMapper()
        {

            CreateMap<LivroCriacaoDto, LivrosModel>();
            CreateMap<LivrosModel, LivroEdicaoDto>();
        }
    }
}
