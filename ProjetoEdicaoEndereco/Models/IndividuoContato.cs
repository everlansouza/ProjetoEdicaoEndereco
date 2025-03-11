using ProjetoEdicaoEndereco.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAtulizarEndereco.Models
{
    public class IndividuoContato
    {
        [Key]
        public int Id { get; set; }
        public string Ddi { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public WhatsappEnum Whatsapp { get; set; }
        public TipoContatoEnum TipoContato { get; set; }
        public int IndividuoId { get; set; }

        [ForeignKey("IndividuoId")]
        public Individuo Individuo { get; set; }
    }
}
