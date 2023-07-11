using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.Json;
using Confluent.Kafka;
using KafkaProducer.Infra.Kafka;

namespace KafkaProducer.Infra.Kafka;

public class Producer<T>
{

    readonly string? _host;
    readonly int _port;
    readonly string? _topic;

    public Producer()
    {
        _host = "kafka.hom-lionx.com.br";
        _port = 9094;
        _topic = "wallets.movements.reconciliator.tccmovto";
    }

   

    ProducerConfig GetProducerConfig()
    {
        return new ProducerConfig
        {
            BootstrapServers = $"{_host}:{_port}"
        };
    }

    public async Task ProduceAsync(T data)
    {
        using (var producer = new ProducerBuilder<Null, T>(GetProducerConfig())
                                             .SetValueSerializer(new CustomValueSerializer<T>())
                                             .Build())
        {
            await producer.ProduceAsync(_topic, new Message<Null, T> { Value = data });
            WriteLine($"{data} published");
        }
    }
}
