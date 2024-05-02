using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Pais")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
