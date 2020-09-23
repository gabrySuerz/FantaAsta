namespace FantasyAuction.Shared
{
    public class Exception
    {
        public string Message { get; }

        public Exception(string message)
        {
            Message = message;
        }
    }
}
