using FantaAsta.Server.Services.Interfaces;
using FantaAsta.Shared;
using Microsoft.AspNetCore.SignalR;

namespace FantaAsta.Server.Hubs
{
    public class FantaHub : Hub
    {
        private readonly IFantaGestoreService _fantaGestoreService;

        public FantaHub(IFantaGestoreService fantaGestoreService)
        {
            _fantaGestoreService = fantaGestoreService;
        }

        public async void InvioOfferta(Offerta offerta)
        {
            if (_fantaGestoreService.AstaInCorso())
            {
                _fantaGestoreService.InserisciOfferta(offerta);
            }
            else
            {
                await Clients.All.SendAsync("RicezioneOfferta", offerta);
            }
        }
    }
}