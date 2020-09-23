using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyAuction.Shared;

namespace FantasyAuction.Server.Services.Interfaces
{
    public interface IAuctionHandlerService
    {
        /// <summary>
        /// Refreshes the players data from the api endpoint wrote in configuration.
        /// </summary>
        void RefreshPlayersData();

        /// <summary>
        /// Gets the complete list players.
        /// </summary>
        /// <returns>A list of players.</returns>
        IEnumerable<Player> GetPlayers();

        /// <summary>
        /// Gets the state of the auction.
        /// </summary>
        /// <returns>When in progress returns true.</returns>
        bool GetAuctionState();

        /// <summary>
        /// Starts the auction.
        /// It will automatically send a new player every 30 sec to all clients.
        /// </summary>
        void StartAuction();

        /// <summary>
        /// Starts the player negotiation.
        /// It will send the player info to all clients.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        void StartPlayerNegotiation(string playerId);

        /// <summary>
        /// Adds the bid and selects the winner of the current pick.
        /// </summary>
        /// <param name="bid">The bid.</param>
        void InsertAndCompareBid(Bid bid);

        /// <summary>
        /// Gets the sold players.
        /// </summary>
        /// <returns>List of sold players.</returns>
        IEnumerable<SoldPlayer> GetSoldPlayers();
    }
}