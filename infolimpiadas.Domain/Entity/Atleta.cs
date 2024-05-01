namespace infolimpiadas.Domain.Entity
{
    public class Atleta
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Pais Naturalidade { get; set; }
        public int Idade { get; set; }
        public Modalidade Modalidade { get; set; }
        public List<Medalha> Medalhas { get; set; }
        public int Participacoes { get; set; }
        public string FotoUrl { get; set; }
    }
}
