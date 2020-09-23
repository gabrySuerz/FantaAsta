﻿using FantasyAuction.Server.Hubs;
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

namespace FantasyAuction.Server.Services
{
    public class AuctionHandlerService : IAuctionHandlerService
    {
        private readonly ILogger _logger;
        private readonly DataApi _dataApi;
        private readonly IHubContext<AuctionHub> _auctionAuction;

        private bool _isAuctionInProgress;
        private IEnumerable<Player> _players;
        private IEnumerable<SoldPlayer> _soldPlayers;

        public AuctionHandlerService(
            ILogger<AuctionHandlerService> logger,
            IOptions<DataApi> dataApiConfig,
            IHubContext<AuctionHub> auctionContext
        )
        {
            _logger = logger;
            _dataApi = dataApiConfig.Value;
            _auctionAuction = auctionContext;
            _players = new List<Player>();
            _soldPlayers = new List<SoldPlayer>();
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
                _players = endpointResponse.Data;
            }
            _players = new List<Player>
                {
                    new Player
                    {
                        Img =
                            "data:image/jpeg;base64,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",
                        Nome = "ciccio pasticcio"
                    },
                    new Player
                    {
                        Img =
                            "data:image/jpeg;base64,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",
                        Nome = "ciccio pasticcio v2"
                    }
                };
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players.ToArray();
        }

        public void StartAuction()
        {
            if (!_isAuctionInProgress)
            {
                ClearAndStart();
                ExecuteAuction();
                EndAuction();
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
            await _auctionAuction.Clients.All.SendAsync("StartAuction", 10);
            Thread.Sleep(10000);
        }

        private async void ExecuteAuction()
        {
            var playersToPick = _players.ToList();
            while (playersToPick.Any())
            {
                var player = playersToPick.First();
                await _auctionAuction.Clients.All.SendAsync("ReceivePlayer", player);
                Thread.Sleep(30000);
                playersToPick = playersToPick.Where(g => g.Id != player.Id).ToList();
                Thread.Sleep(10000);
            }
        }

        private async void EndAuction()
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


        public void StartPlayerNegotiation(string playerId)
        {
            var giocatore = _players.FirstOrDefault(p => p.Id == playerId);
            _auctionAuction.Clients.All.SendAsync("InvioGiocatore", giocatore);
        }

        public IEnumerable<SoldPlayer> GetSoldPlayers()
        {
            return _soldPlayers.ToArray();
        }
    }
}