using System.Collections.Generic;
using FantaAsta.Shared;

namespace FantaAsta.Server.Services.Interfaces
{
    public interface IFantaGestoreService
    {
        IEnumerable<Giocatore> GetGiocatori();

        void InizioAstaAutomatica();

        void NegoziaGiocatore(string giocatoreId);

        void InserisciOfferta(Offerta offerta);

        bool AstaInCorso();

        IEnumerable<GiocatoreAggiudicato> GiocatoriAggiudicati();
    }
}