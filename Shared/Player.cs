namespace FantasyAuction.Shared
{
    public class Player
    {
         public string Id { get; set; }

         public string Name { get; set; }

         public string Role { get; set; }

         public string SpecificRole { get; set; }

         public string Img { get; set; }

         public int Cost { get; set; }

         public Team Team { get; set; }
    }
}