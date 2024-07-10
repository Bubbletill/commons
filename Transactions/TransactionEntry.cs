using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions;

public class TransactionEntry
{
    public int Utid { get; set; }
    public int Store { get; set; }
    public int Register { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public int TransactionId { get; set; }
    public TransactionType Type { get; set; }
    public string OperatorId { get; set; }
    public string Basket { get; set; }
    public int Amount { get; set; }
    public string Tenders { get; set; }
    public TransactionType PostTransType { get; set; }
}
