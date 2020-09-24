using FantasyAuction.Client.Entities;
using System;
using System.Collections.Generic;

namespace FantasyAuction.Client.Services
{
    public class AlertService
    {
        public List<IAlert> Messages { get; private set; }
        public event Action RefreshRequested;

        public AlertService()
        {
            this.Messages = new List<IAlert>();
        }

        public void AddMessage(Alert alert)
        {
            Messages.Add(alert);
            System.Console.WriteLine("Message count: {0}", this.Messages.Count);
            RefreshRequested?.Invoke();

            // pop message off after a delay
            new System.Threading.Timer((_) => {
                Messages.RemoveAt(0);
                RefreshRequested?.Invoke();
            }, null, 8000, System.Threading.Timeout.Infinite);
        }
    }
}
