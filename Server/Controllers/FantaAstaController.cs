using FantaAsta.Server.Services.Interfaces;
using FantaAsta.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FantaAsta.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FantaAstaController : ControllerBase
    {
        private readonly ILogger<FantaAstaController> _logger;
        private readonly IFantaGestoreService _fantaGestoreService;

        public FantaAstaController(
            ILogger<FantaAstaController> logger,
            IFantaGestoreService fantaGestoreService
        )
        {
            _logger = logger;
            _fantaGestoreService = fantaGestoreService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Giocatore> Giocatori()
        {
            return _fantaGestoreService.GetGiocatori();
        }

        [HttpPatch("[action]")]
        public void InizioAstaCompletaAutomatica()
        {
            _fantaGestoreService.InizioAstaAutomatica();
        }

        [HttpGet("[action]")]
        public bool AstaInCorso()
        {
            return _fantaGestoreService.AstaInCorso();
        }

        [HttpPatch("[action]/{id}")]
        public void NegoziaGiocatore([FromRoute] string id)
        {
            _fantaGestoreService.NegoziaGiocatore(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<GiocatoreAggiudicato> GiocatoriAggiudicati()
        {
            return _fantaGestoreService.GiocatoriAggiudicati();
        }
    }
}