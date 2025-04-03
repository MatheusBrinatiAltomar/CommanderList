using Hangfire;
using MagicCardInfo.Application.Services;

namespace MagicCardInfo.Worker;

public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Worker Service Started...");

        RecurringJob.AddOrUpdate<CardService>(
            "get-card-data",
            job => job.AddOrUpdateCardsAsync(),
            Cron.Hourly);

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
