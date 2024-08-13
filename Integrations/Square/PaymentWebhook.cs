using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Integrations.Square;

public class PaymentWebhook
{
    public string merchant_id { get; set; }
    public string type { get; set; }
    public string event_id { get; set; }
    public string created_at { get; set; }
    public PaymentData data { get; set; }
}
