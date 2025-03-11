using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAtulizarEndereco.Models
{
    public class IndividuoEndereco
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IndividuoId { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }

        [ForeignKey("IndividuoId")]
        public Individuo Individuo { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }
        
        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
    }
}
