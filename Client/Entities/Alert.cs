namespace FantasyAuction.Client.Entities
{
    public class Alert : IAlert
    {
        public string Message { get; set; }

        public AlertType AlertType { get; set; }

        public Alert() { }

        public Alert(string message, AlertType alertType)
        {
            this.Message = message;
            this.AlertType = alertType;
        }
    }
}
