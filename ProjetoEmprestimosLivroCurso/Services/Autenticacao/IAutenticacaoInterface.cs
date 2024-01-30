namespace ProjetoEmprestimosLivroCurso.Services.Autenticacao
{
    public interface IAutenticacaoInterface
    {
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    }
}
