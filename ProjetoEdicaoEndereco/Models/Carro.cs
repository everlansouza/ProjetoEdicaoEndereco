using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAtulizarEndereco.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int IndividuoId { get; set; }

        [ForeignKey("IndividuoId")]
        public Individuo Individuo { get; set; }
    }
}
