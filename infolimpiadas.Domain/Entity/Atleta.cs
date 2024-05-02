using infolimpiadas.Domain.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Atleta")]
    public class Atleta : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        //public Pais Naturalidade { get; set; }
        public int Idade { get; set; }
        //public Modalidade Modalidade { get; set; }
        //public List<Medalha> Medalhas { get; set; }
        public int Participacoes { get; set; }
        public string FotoUrl { get; set; }
    }
}
