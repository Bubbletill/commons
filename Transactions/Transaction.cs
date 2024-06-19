using BT_COMMONS.Operators;
using BT_COMMONS.Transactions.TenderAttributes;

namespace BT_COMMONS.Transactions;

public class Transaction
{
    public int Store { get; set; }
    public int Register { get; set; }
    public DateTime DateTime { get; set; }
    public int TransactionId { get; set; }
    public TransactionType Type { get; set; }
    public Operator Operator { get; set; }
    public List<BasketItem> Basket { get; set; }
    public BasketItem SelectedItem { get; set; }

    public Dictionary<TransactionTender, float> Tenders { get; set; }
    public float Change { get; set; } = 0;
    private TransactionTender ChangeType;

    public List<TransactionLog> Logs { get; set; }

    public TransactionType PostTransType { get; set; }

    public Transaction()
    {
        Basket = new List<BasketItem>();
        Tenders = new Dictionary<TransactionTender, float>();
        Logs = new List<TransactionLog>();
    }

    public void Init(int store, int register, Operator oper, DateTime dateTime, int transid, TransactionType type)
    {
        Store = store;
        Register = register;
        Operator = oper;
        DateTime = dateTime;
        TransactionId = transid;
        Type = type;

        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Transaction " + transid + " started by " + Operator.ReducedName() + ", ID " + Operator.OperatorId + " at " + dateTime.ToString()));
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Transaction type of " + type.ToString()));
    }

    public void UpdateTransactionType(TransactionType type)
    {
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Transaction is now type of " + type.ToString()));
        Type = type;
    }

    public void AddToBasket(BasketItem item)
    {
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "New Item: " + item.Code + " - " + item.Description + " (FP" + item.FilePrice + ")"));
        foreach (BasketItem b in Basket)
        {
            if (b.Code == item.Code)
            {
                b.Quantity++;
                return;
            }
        }

        Basket.Add(item);
    }

    public bool VoidBasketItem(BasketItem item)
    {
        if (item == null || !Basket.Contains(item))
            return false;

        Basket.Remove(item);
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Voided Item: " + item.Code + " - " + item.Description));
        return true;
    }

    public float GetSubTotal()
    {
        float total = 0;
        Basket.ForEach(item => { total += (item.FilePrice * item.Quantity); });
        return total;
    }

    public float GetTotal()
    {
        float total = 0;
        Basket.ForEach(item => { total += (item.FilePrice * item.Quantity); });
        return total;
    }

    public float GetAmountTendered()
    {
        float tendered = 0;
        foreach (KeyValuePair<TransactionTender, float> entry in Tenders)
        {
            tendered += entry.Value;
        }

        return tendered;
    }

    public float GetRemainingTender()
    {
        float tendered = GetAmountTendered();
        float remaining = GetTotal() - tendered;
        return (remaining > 0 ? remaining : 0);
    }

    public bool IsTenderComplete()
    {
        return GetAmountTendered() >= GetTotal();
    }

    public void AddTender(TransactionTender type, float amount)
    {
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Tendered " + type.GetTenderInternalName() + ": £" + amount));
        Logs.Add(new TransactionLog(TransactionLogType.Tender, type.GetTenderExternalName() + ": £" + amount));

        if (amount > GetRemainingTender())
        {
            ChangeType = type;
            Change = amount - GetRemainingTender();
            Logs.Add(new TransactionLog(TransactionLogType.Tender, "CHANGE: £" + Change));
        }

        var current = Tenders.GetValueOrDefault(type, 0);
        current += amount;
        Tenders[type] = current;
    }

    public void VoidTender()
    {
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Tender Voided at " + DateTime.Now.ToString()));
        Tenders.Clear();
        for (int i = Logs.Count - 1; i >= 0; i--)
        {
            if (Logs[i].Type == TransactionLogType.Tender || Logs[i].Type == TransactionLogType.PostTender)
            {
                Logs.RemoveAt(i);
            }
        }
    }

    public TransactionTender GetChangeTender()
    {
        return ChangeType;
    }

    public bool ShouldCashDrawOpen()
    {
        foreach (KeyValuePair<TransactionTender, float> entry in Tenders)
        {
            if (entry.Key.OpenCashDraw())
                return true;
        }

        return false;
    }

}
