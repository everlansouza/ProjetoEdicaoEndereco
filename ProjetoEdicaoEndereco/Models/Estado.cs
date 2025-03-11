using System.ComponentModel.DataAnnotations;

namespace SistemaAtulizarEndereco.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
    }
}
