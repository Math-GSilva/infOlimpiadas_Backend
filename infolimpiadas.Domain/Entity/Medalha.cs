using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Medalha")]
    public class Medalha
    {
        [Key]
        public int Id { get; set; }
        public string Cor { get; set; }
        public DateTime DataConquista { get; set; }
    }

    public enum CorMedalha
    {
        Ouro,
        Prata,
        Bronze
    }
}
