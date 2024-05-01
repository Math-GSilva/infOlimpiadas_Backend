namespace infolimpiadas.Domain.Entity
{
    public class Medalha
    {
        public int Id { get; set; }
        public CorMedalha Cor { get; set; }
        public DateTime DataConquista { get; set; }
    }

    public enum CorMedalha
    {
        Ouro,
        Prata,
        Bronze
    }
}
