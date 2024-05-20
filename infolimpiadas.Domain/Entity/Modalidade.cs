using infolimpiadas.Domain.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Modalidade")]
    public class Modalidade : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
