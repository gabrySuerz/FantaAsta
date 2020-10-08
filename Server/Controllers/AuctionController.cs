using FantasyAuction.Server.Services.Interfaces;
using FantasyAuction.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        [HttpPatch("[action]")]
        public void RefreshPlayersData()
        {
            _auctionHandlerService.RefreshPlayersData();
        }

        [HttpPatch("[action]")]
        public void StartAuction([FromQuery] string connectionId)
        {
            _auctionHandlerService.StartAuction(connectionId);
        }

        [HttpPatch("[action]")]
        public void EndAuction()
        {
            _auctionHandlerService.EndAuction();
        }

        [HttpPatch("[action]/{id}")]
        public void StartPlayerNegotiation([FromRoute] string id, [FromQuery] string connectionId)
        {
            _auctionHandlerService.StartPlayerNegotiation(id, connectionId);
        }

        [HttpGet("[action]")]
        public IEnumerable<SoldPlayer> GetSoldPlayers()
        {
            return _auctionHandlerService.GetSoldPlayers();
        }

        [HttpPatch("[action]")]
        public void ClearSoldPlayers()
        {
            _auctionHandlerService.ClearSoldPlayers();
        }
    }
}