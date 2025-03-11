using Microsoft.EntityFrameworkCore;

namespace ProjetoEdicaoEndereco.Data
{
    public class ProjetoEdicaoEnderecoContext : DbContext
    {
        public ProjetoEdicaoEnderecoContext (DbContextOptions<ProjetoEdicaoEnderecoContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaAtulizarEndereco.Models.Individuo> Individuo { get; set; } = default!;
        public DbSet<SistemaAtulizarEndereco.Models.IndividuoContato> IndividuoContato { get; set; } = default!;
        public DbSet<SistemaAtulizarEndereco.Models.IndividuoEndereco> IndividuoEndereco { get; set; } = default!;
        public DbSet<SistemaAtulizarEndereco.Models.Carro> Carro { get; set; } = default!;
        public DbSet<SistemaAtulizarEndereco.Models.Cidade> Cidade { get; set; } = default!;
        public DbSet<SistemaAtulizarEndereco.Models.Estado> Estado { get; set; } = default!;
    }
}
