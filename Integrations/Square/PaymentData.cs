using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Integrations.Square;

public class PaymentData
{
    public string type { get; set; }
    public string id { get; set; }
    [JsonProperty("object")]
    public PaymentObject obj { get; set; }
}
