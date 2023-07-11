using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducer.Infra.Kafka
{
    public class ClientReconciliationListMessage
    {
        public int AccountNumber { get; set; }
        public decimal SinacorAmount { get; set; }
        public decimal PicPayAmount { get; set; }
        public string CustomerDocument { get; set; } = "";
    }

    public class MessageReconciliationDto
    {
        public MessageReconciliationDto()
        {
            clientReconciliationListMessages = new List<ClientReconciliationListMessage>();
        }
        public List<ClientReconciliationListMessage> clientReconciliationListMessages { get; set; } 
    }
}
