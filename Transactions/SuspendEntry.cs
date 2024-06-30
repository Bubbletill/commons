using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions;

public class SuspendEntry
{
    public int Sid { get; set; }
    public string Data { get; set; }
    public Transaction Transaction { get; set; }
}
