using BT_COMMONS.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.App;

public class HardTotals
{
    public Dictionary<TransactionTender, float>? Tender { get; set; }
    public Dictionary<TransactionType, float>? Type { get; set; } 
}
