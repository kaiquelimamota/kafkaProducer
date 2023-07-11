using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KafkaProducer.Infra.Kafka;

public class Message
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Data { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
