using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions;

public class TransactionLog
{
    public TransactionLogType Type { get; set; }
    public string Log{ get; set; }

    public TransactionLog(TransactionLogType type, string log)
    {
        Type = type;
        Log = log;
    }
}
