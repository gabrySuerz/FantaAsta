using FantaAsta.Server.Hubs;
using FantaAsta.Server.Services.Interfaces;
using FantaAsta.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FantaAsta.Server.Services
{
    public class FantaGestoreService : IFantaGestoreService
    {
        private readonly ILogger _logger;
        private readonly DataApi _dataApi;
        private readonly IHubContext<FantaHub> _fantaHub;

        private bool _astaInCorso;
        private IEnumerable<Giocatore> _giocatori;
        private IEnumerable<GiocatoreAggiudicato> _giocatoriAggiudicati;

        public FantaGestoreService(
            ILogger<FantaGestoreService> logger,
            IOptions<DataApi> dataApiConfig,
            IHubContext<FantaHub> hubContext
        )
        {
            _dataApi = dataApiConfig.Value;
            _giocatori = PopolamentoDati().Result;
            _fantaHub = hubContext;
        }

        private async Task<IEnumerable<Giocatore>> PopolamentoDati()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_dataApi.Endpoint)
            };

            using var response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var baseObject =
                    JsonConvert.DeserializeObject<RispostaEndpoint>(response.Content.ReadAsStringAsync().Result);
                return baseObject.Data;
            }

            return new List<Giocatore>();
        }

        public IEnumerable<Giocatore> GetGiocatori()
        {
            return _giocatori;
        }

        public async void InizioAstaAutomatica()
        {
            if (!_astaInCorso)
            {
                _astaInCorso = true;
                _giocatoriAggiudicati = new List<GiocatoreAggiudicato>();
                var giocatoriDaChiamare = _giocatori;
                while (giocatoriDaChiamare.Any())
                {
                    var giocatore = giocatoriDaChiamare.First();
                    await _fantaHub.Clients.All.SendAsync("InvioGiocatore", giocatore);
                    await Task.Delay(30000);
                    giocatoriDaChiamare = giocatoriDaChiamare.Where(g => g.Id != giocatore.Id);
                }

                _astaInCorso = false;
            }
            else
            {
                _logger.LogInformation(
                    "Qualcuno sta cercando di iniziare un'asta.... ma dovrebbe controllare se c'è n'è già una in corso");
            }
        }

        public void InserisciOfferta(Offerta offerta)
        {
            var giocatore = _giocatoriAggiudicati.FirstOrDefault(g => g.Id == offerta.GiocatoreId);
            if (giocatore != null)
            {
                if (giocatore.ImportoOfferta < offerta.Importo)
                {
                    giocatore.ImportoOfferta = offerta.Importo;
                    giocatore.OfferenteVincitore = offerta.Offerente;
                }
            }
            else
            {
                _giocatoriAggiudicati.ToList().Add(new GiocatoreAggiudicato
                {
                    Id = offerta.GiocatoreId,
                    Giocatore = _giocatori.FirstOrDefault(g => g.Id == offerta.GiocatoreId),
                    ImportoOfferta = offerta.Importo,
                    OfferenteVincitore = offerta.Offerente
                });
            }
        }

        public bool AstaInCorso()
        {
            return _astaInCorso;
        }

        public void NegoziaGiocatore(string giocatoreId)
        {
            var giocatore = _giocatori.FirstOrDefault(giocatore => giocatore.Id == giocatoreId);
            _fantaHub.Clients.All.SendAsync("InvioGiocatore", giocatore);
        }

        public IEnumerable<GiocatoreAggiudicato> GiocatoriAggiudicati()
        {
            return _giocatoriAggiudicati;
        }
    }
}