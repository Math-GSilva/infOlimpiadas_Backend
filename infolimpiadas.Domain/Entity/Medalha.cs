﻿using infolimpiadas.Domain.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Medalha")]
    public class Medalha : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
