using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KafkaProducer.Infra.Kafka;

public class Consumer<T>
{
    readonly string? _host;
    readonly int _port;
    readonly string? _topic;

    public Consumer()
    {
        _host = "kafka.hom-lionx.com.br";
        _port = 9094;
        _topic = "wallets.movements.reconciliator.tccmovto";
    }

    ConsumerConfig GetConsumerConfig()
    {
        return new ConsumerConfig
        {
            BootstrapServers = $"{_host}:{_port}",
            GroupId = "foo",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }

    public async Task ConsumeAsync()
    {
        using (var consumer = new ConsumerBuilder<Ignore, T>(GetConsumerConfig())
            .SetValueDeserializer(new CustomValueDeserializer<T>())
            .Build())
        {
            consumer.Subscribe(_topic);

            WriteLine($"Subscribed to {_topic}");

            await Task.Run(() =>
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(default(CancellationToken));

                    if (consumeResult.Message.Value is Message result)
                    {
                        WriteLine($"Data Received - {result}");
                    }
                }
            });

            consumer.Close();
        }
    }
}
