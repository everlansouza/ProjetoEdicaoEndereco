using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAtulizarEndereco.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int EstadosId { get; set; }

        [ForeignKey("EstadosId")]
        public Estado Estado { get; set; }
    }
}
