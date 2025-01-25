using Microsoft.Extensions.Hosting;

namespace RapidPay.Services.Implementations
{
    public class HourlyTaskService : IHostedService, IDisposable
    {
        private readonly UFEService _ufeService;
        private static Timer _timer;

        public HourlyTaskService()
        {
            _ufeService = UFEService.Instance;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(updateFee, null, TimeSpan.Zero, TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private void updateFee(object state) 
        { 
            _ufeService.UpdateFee();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
