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

    public Dictionary<TransactionTender, float> Tenders { get; set; }
    public float Change { get; set; } = 0;
    private TransactionTender ChangeType;

    public List<string> Logs { get; set; }

    public TransactionType PostTransType { get; set; }

    public Transaction()
    {
        Basket = new List<BasketItem>();
        Tenders = new Dictionary<TransactionTender, float>();
        Logs = new List<string>();
    }

    public void Init(int store, int register, Operator oper, DateTime dateTime, int transid, TransactionType type)
    {
        Store = store;
        Register = register;
        Operator = oper;
        DateTime = dateTime;
        TransactionId = transid;
        Type = type;

        Logs.Add("Transaction " + transid + " started by " + Operator.ReducedName() + ", ID " + Operator.OperatorId + " at " + dateTime.ToString());
        Logs.Add("Transaction type of " + type.ToString());
    }

    public void UpdateTransactionType(TransactionType type)
    {
        Logs.Add("Transaction is now type of " + type.ToString());
        Type = type;
    }

    public void AddToBasket(BasketItem item)
    {
        Logs.Add("New Item: " + item.Code + " - " + item.Description + " (FP" + item.FilePrice + ")");
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
        return GetTotal() - tendered;
    }

    public bool IsTenderComplete()
    {
        return GetAmountTendered() >= GetTotal();
    }

    public void AddTender(TransactionTender type, float amount)
    {
        Logs.Add("Tendered " + type.GetTenderInternalName() + " £" + amount);

        if (amount > GetRemainingTender())
        {
            ChangeType = type;
            Change = amount - GetRemainingTender();
            Logs.Add("Tender Change: £" + Change);
        }

        var current = Tenders.GetValueOrDefault(type, 0);
        current += amount;
        Tenders[type] = current;
    }

    public void VoidTender()
    {
        Logs.Add("Tender Voided at " + DateTime.Now.ToString());
        Tenders.Clear();
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
