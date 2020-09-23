namespace FantasyAuction.Shared
{
    public class SoldPlayer
    {
        public string Id { get; set; }

        public Player Player { get; set; }

        public string BiddingWinner { get; set; }

        public long OfferAmount { get; set; }
    }
}