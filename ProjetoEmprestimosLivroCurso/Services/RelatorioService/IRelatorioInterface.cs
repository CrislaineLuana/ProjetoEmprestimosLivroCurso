using System.Data;

namespace ProjetoEmprestimosLivroCurso.Services.RelatorioService
{
    public interface IRelatorioInterface
    {
        DataTable ColetarDados<T>(List<T> dados, int idRelatorio);
    }
}
