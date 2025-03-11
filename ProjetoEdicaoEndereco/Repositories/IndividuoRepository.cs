using Microsoft.EntityFrameworkCore;
using ProjetoEdicaoEndereco.Data;
using SistemaAtulizarEndereco.Models;

namespace ProjetoEdicaoEndereco.Repositories;

public class IndividuoRepositorio : IIndividuoRepositorio
{
    private readonly ProjetoEdicaoEnderecoContext _context;

    public IndividuoRepositorio(ProjetoEdicaoEnderecoContext context)
    {
        _context = context;
    }

    public Individuo ObterPorDocumentoEPlaca(string documento, string placa)
    {
        return _context.Individuo
            .Include(i => i.Carro)
            .FirstOrDefault(i => i.Documento == documento && i.Carro.Placa == placa);
    }

    public Individuo ObterPorId(int id)
    {
        return _context.Individuo
            .Include(i => i.Carro)
            .Include(i => i.IndividuoContato)
            .Include(i => i.IndividuoEndereco)
            .ThenInclude(e => e.Estado)
            .Include(i => i.IndividuoEndereco)
            .ThenInclude(c => c.Cidade)
            .FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<Individuo> ListarTodos()
    {
        return _context.Individuo.ToList();
    }
}