using AutoMapper;
using FantasyAuction.Server.Entities;
using FantasyAuction.Server.Hubs;
using FantasyAuction.Server.Services.Interfaces;
using FantasyAuction.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyAuction.Server.Services
{
    public class AuctionHandlerService : IAuctionHandlerService
    {
        private readonly ILogger _logger;
        private readonly DataApi _dataApi;
        private readonly IHubContext<AuctionHub> _auctionAuction;
        private readonly IMapper _mapper;

        private bool _isAuctionInProgress;
        private IEnumerable<Player> _players;
        private IEnumerable<SoldPlayer> _soldPlayers;
        private string _connectionId;
        private int _biddingTime;
        private int _waitingTime;

        public AuctionHandlerService(
            ILogger<AuctionHandlerService> logger,
            IOptions<DataApi> dataApiConfig,
            IHubContext<AuctionHub> auctionContext,
            IMapper mapper
        )
        {
            _logger = logger;
            _dataApi = dataApiConfig.Value;
            _auctionAuction = auctionContext;
            _players = new List<Player>();
            _soldPlayers = new List<SoldPlayer>();
            _mapper = mapper;

            _waitingTime = 10;
            _biddingTime = 20;
        }

        public async void RefreshPlayersData()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_dataApi.Endpoint)
            };

            using var response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var endpointResponse = JsonConvert.DeserializeObject<EndpointResponse>(response.Content.ReadAsStringAsync().Result);
                _players = _mapper.Map<IEnumerable<Player>>(endpointResponse.Data);
                _players.ToList().ForEach(p =>
                {
                    if (!string.IsNullOrWhiteSpace(p.Img)
                        && !p.Img.ToLower().StartsWith("http://")
                        && !p.Img.ToLower().StartsWith("https://")
                    )
                    {
                        p.Img = $"https://www.fantaformazione.com/{p.Img}";
                    }
                });
            }
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players;
        }

        public void StartAuction(string connectionId)
        {
            if (!_isAuctionInProgress)
            {
                _ = new Task(() =>
                {
                    _connectionId = connectionId;
                    ClearAndStart();
                    ExecuteAuction();
                    EndAuction();
                });
            }
            else
            {
                _logger.LogInformation(
                    "Qualcuno sta cercando di iniziare un'asta.... ma dovrebbe controllare se c'è n'è già una in corso");
            }
        }

        private async void ClearAndStart()
        {
            _isAuctionInProgress = true;
            _soldPlayers = new List<SoldPlayer>();
            await _auctionAuction.Clients.All.SendAsync("AuctionStarted", _waitingTime);
            Thread.Sleep(_waitingTime * 1000);
        }

        private async void ExecuteAuction()
        {
            var playersToPick = _players.ToList();
            while (playersToPick.Any())
            {
                var player = playersToPick.First();
                await _auctionAuction.Clients.All.SendAsync("ReceivePlayer", player, _biddingTime);
                Thread.Sleep(_biddingTime * 1000);
                playersToPick = playersToPick.Where(g => g.Id != player.Id).ToList();
                await _auctionAuction.Clients.All.SendAsync("WaitNextPlayer", _waitingTime);
                Thread.Sleep(_waitingTime * 1000);
            }
        }

        public async void EndAuction()
        {
            _isAuctionInProgress = false;
            await _auctionAuction.Clients.All.SendAsync("AuctionEnded");
        }

        public void InsertAndCompareBid(Bid bid)
        {
            var player = _soldPlayers.FirstOrDefault(g => g.Id == bid.PlayerId);
            if (player != null)
            {
                if (player.OfferAmount < bid.Amount)
                {
                    player.OfferAmount = bid.Amount;
                    player.BiddingWinner = bid.Bidder;
                }
            }
            else
            {
                _soldPlayers = _soldPlayers.Append(new SoldPlayer
                {
                    Id = bid.PlayerId,
                    Player = _players.FirstOrDefault(g => g.Id == bid.PlayerId),
                    OfferAmount = bid.Amount,
                    BiddingWinner = bid.Bidder
                });
            }
        }

        public bool GetAuctionState()
        {
            return _isAuctionInProgress;
        }

        public string GetAdministratorConnectionId()
        {
            return _connectionId;
        }

        public void StartPlayerNegotiation(string playerId, string connectionId)
        {
            var giocatore = _players.FirstOrDefault(p => p.Id == playerId);
            _auctionAuction.Clients.All.SendAsync("ReceivePlayer", giocatore, _biddingTime);
        }

        public IEnumerable<SoldPlayer> GetSoldPlayers()
        {
            return _soldPlayers;
        }

        public void ClearSoldPlayers()
        {
            _soldPlayers = new List<SoldPlayer>();
        }
    }
}