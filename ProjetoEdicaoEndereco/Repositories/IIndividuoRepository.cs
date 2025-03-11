using SistemaAtulizarEndereco.Models;

namespace ProjetoEdicaoEndereco.Repositories
{
    public interface IIndividuoRepositorio
    {
        Individuo ObterPorDocumentoEPlaca(string documento, string placa);
        
        Individuo ObterPorId(int id);
        
        IEnumerable<Individuo> ListarTodos();
    }
}
