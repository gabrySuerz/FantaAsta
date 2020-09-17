namespace FantaAsta.Shared
{
    public class GiocatoreAggiudicato
    {
        public string Id { get; set; }

        public Giocatore Giocatore { get; set; }

        public string OfferenteVincitore { get; set; }

        public long ImportoOfferta { get; set; }
    }
}