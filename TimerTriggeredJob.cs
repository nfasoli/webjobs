using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

public class TimerTriggeredJob
{
    public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo timerInfo, ILogger logger)
    {
        logger.LogInformation($"Timer triggered at: {DateTime.Now}");
    }
}
