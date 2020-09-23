﻿using FantasyAuction.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using FantasyAuction.Server.Services.Interfaces;

namespace FantasyAuction.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionHandlerService _auctionHandlerService;

        public AuctionController(
            ILogger<AuctionController> logger,
            IAuctionHandlerService auctionHandlerService
        )
        {
            _logger = logger;
            _auctionHandlerService = auctionHandlerService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Player> GetPlayers()
        {
            return _auctionHandlerService.GetPlayers();
        }

        [HttpGet("[action]")]
        public bool AuctionState()
        {
            return _auctionHandlerService.GetAuctionState();
        }

        [HttpPatch("[action]")]
        public void RefreshPlayersData()
        {
            _auctionHandlerService.RefreshPlayersData();
        }

        [HttpPatch("[action]")]
        public void StartAuction()
        {
            _auctionHandlerService.StartAuction();
        }

        [HttpPatch("[action]/{id}")]
        public void StartPlayerNegotiation([FromRoute] string id)
        {
            _auctionHandlerService.StartPlayerNegotiation(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<SoldPlayer> GetSoldPlayers()
        {
            return _auctionHandlerService.GetSoldPlayers();
        }
    }
}