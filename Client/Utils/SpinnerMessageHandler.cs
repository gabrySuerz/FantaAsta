using FantasyAuction.Client.Services;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyAuction.Client.Utils
{
    public class SpinnerMessageHandler : DelegatingHandler
    {
        private readonly SpinnerService _spinnerService;

        public SpinnerMessageHandler(SpinnerService spinnerService)
        {
            _spinnerService = spinnerService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _spinnerService.Show();
            var response = await base.SendAsync(request, cancellationToken);
            _spinnerService.Hide();
            return response;
        }
    }
}