using Newtonsoft.Json;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Integrations.Square;

public class TerminalCheckoutData
{
    public string type { get; set; }
    public string id { get; set; }
    [JsonProperty("object")]
    public TerminalCheckoutObject obj { get; set; }
}
