using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAtulizarEndereco.Models
{
    public class Individuo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public Carro Carro { get; set; }
        public IndividuoContato IndividuoContato { get; set; }
        public IndividuoEndereco IndividuoEndereco { get; set; }
    }
}
