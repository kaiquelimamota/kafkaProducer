using Confluent.Kafka;
using KafkaProducer.Infra.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace kafkaProducer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost("ProducerMessage")]
    public async void ProducerMessage()
    {
        try
        {
            var producer = new Producer<MessageReconciliationDto>();

            var client = new ClientReconciliationListMessage()
            {
                AccountNumber = 123,
                CustomerDocument = "41406340812",
                PicPayAmount = 10,
                SinacorAmount = 15
            };

            var message = new MessageReconciliationDto()
            {
                clientReconciliationListMessages =
                new List<ClientReconciliationListMessage>()
            };

            message.clientReconciliationListMessages.Add(client);
            Console.WriteLine("Enviando!!!!!");

            await producer.ProduceAsync(message);

            Console.WriteLine("Enviado!!!!!!!");
        }
        catch (Exception ex)
        {
            var test = ex.ToString();
            throw;
        }
    }

}
