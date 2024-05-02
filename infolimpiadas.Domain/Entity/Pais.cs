using infolimpiadas.Domain.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Pais")]
    public class Pais : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
