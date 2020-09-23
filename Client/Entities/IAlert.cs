namespace FantasyAuction.Client.Entities
{
    public interface IAlert
    {
        string Message { get; set; }
        AlertType AlertType { get; set; }
    }
}
