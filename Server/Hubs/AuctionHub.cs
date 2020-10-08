using FantasyAuction.Server.Services.Interfaces;
using FantasyAuction.Shared;
using Microsoft.AspNetCore.SignalR;

namespace FantasyAuction.Server.Hubs
{
    public class AuctionHub : Hub
    {
        private readonly IAuctionHandlerService _auctionHandlerService;

        public AuctionHub(IAuctionHandlerService auctionHandlerService)
        {
            _auctionHandlerService = auctionHandlerService;
        }

        public async void SendBid(Bid bid)
        {
            if (_auctionHandlerService.GetAuctionState())
            {
                _auctionHandlerService.InsertAndCompareBid(bid);
            }
            else
            {
                string connId = _auctionHandlerService.GetAdministratorConnectionId();
                _auctionHandlerService.InsertAndCompareBid(bid);
                await Clients.Client(connId).SendAsync("ReceivedBid", bid);
            }
        }
    }
}