using System.Runtime.Serialization;

namespace shipping.models
{
    [DataContract(Name = "DeliveryOrder")]
    public class DeliveryOrderDto
    {
        [DataMember(Name = "Id")]
        public string Id {get; set; }

        [DataMember(Name = "Recipient")]
        public string Recipient {get; set; }
    }
}