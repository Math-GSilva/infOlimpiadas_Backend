﻿using infolimpiadas.Domain.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infolimpiadas.Domain.Entity
{
    [Table("Usuario")]
    public class Usuario : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
