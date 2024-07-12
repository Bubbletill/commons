using BT_COMMONS.Operators;
using BT_COMMONS.Transactions.TenderAttributes;
using BT_COMMONS.Transactions.TypeAttributes;
using System.Text.Json.Serialization;

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
    public Dictionary<int, ReturnEntry> ReturnBasket { get; set; }
    public BasketItem SelectedItem { get; set; }
    public int CustomerAge { get; set; }

    public float Total { 
        get {
            return GetTotal();
        }
        private set { }
    }

    public string FriendlyType
    {
        get
        {
            return Type.FriendlyName();
        }
        private set { }
    }

    public Dictionary<TransactionTender, float> Tenders { get; set; }
    public float Change { get; set; } = 0;
    private TransactionTender ChangeType;

    public List<TransactionLog> Logs { get; set; }

    public TransactionType PostTransType { get; set; }

    public Transaction()
    {
        Basket = new List<BasketItem>();
        ReturnBasket = new Dictionary<int, ReturnEntry>();
        Tenders = new Dictionary<TransactionTender, float>();
        Logs = new List<TransactionLog>();
        CustomerAge = 0;
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
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Transaction type of " + type.FriendlyName()));
    }

    public void UpdateTransactionType(TransactionType type)
    {
        if (type == Type)
            return;

        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Transaction is now type of " + type.FriendlyName()));
        Type = type;
    }

    public void AddToBasket(BasketItem item)
    {
        if (item.Refund)
        {
            AddRefundToBasket(item);
            return;
        }
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "New Item: " + item.Code + " - " + item.Description + " for " + item.FilePrice));
        
        foreach (BasketItem b in Basket)
        {
            if (b.Code == item.Code && !b.Refund)
            {
                b.Quantity++;
                return;
            }
        }

        Basket.Add(item);
    }

    private void AddRefundToBasket(BasketItem item)
    {
        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Returning Item: " + item.Code + " - " + item.Description + " for " + item.SalePrice));
        Basket.Add(item);
    }

    public bool VoidBasketItem(BasketItem item)
    {
        if (item == null || !Basket.Contains(item))
            return false;

        Basket.Remove(item);

        if (item.Refund)
        {
            ReturnEntry re = ReturnBasket[item.PartOfReturnId];
            BasketItem? bi = re.ParsedBasket.Find(i => i == item);
            if (bi != null)
            {
                bi.Refund = false;
                bi.Returned = false;
            }
        }

        Logs.Add(new TransactionLog(TransactionLogType.Hidden, "Voided Item: " + item.Code + " - " + item.Description));
        return true;
    }

    public float GetSubTotal()
    {
        float total = 0;
        Basket.ForEach(item => { total += item.SalePrice; });
        return total;
    }

    public float GetTotal()
    {
        float total = 0;
        Basket.ForEach(item => { total += item.SalePrice; });
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
        float remaining = Math.Abs(GetTotal()) - tendered;
        return remaining;
    }

    public bool IsTenderComplete()
    {
        return GetAmountTendered() >= Math.Abs(GetTotal());
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
