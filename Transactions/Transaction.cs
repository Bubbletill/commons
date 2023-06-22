namespace BT_COMMONS.Transactions;

public class Transaction
{
    public int Store { get; set; }
    public int Register { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public int TransactionId { get; set; }
    public TransactionType Type { get; set; }
    public string Operator { get; set; }
    public List<BasketItem> Basket { get; set; }
    public Dictionary<TransactionTender, float> Tenders { get; set; }
    public List<string> Logs { get; set; }

    public TransactionType PostTransType { get; set; }

    public Transaction()
    {
        Basket = new List<BasketItem>();
        Tenders = new Dictionary<TransactionTender, float>();
        Logs = new List<string>();
    }

    public void Init(int store, int register, DateOnly date, TimeOnly time, int transid, TransactionType type)
    {
        Store = store;
        Register = register;
        Date = date;
        Time = time;
        TransactionId = transid;
        Type = type;

        Logs.Add("Transaction " + transid + " started by " + Operator + " at " + date.ToString() + " " + time.ToString());
        Logs.Add("Transaction type of " + type.ToString());
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
        Basket.ForEach(item => { total += (item.SalePrice * item.Quantity); });
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
        Logs.Add("Tendered " + type.ToString() + " £" + amount);
        Tenders.Add(type, amount);
    }

    public void VoidTender()
    {
        Logs.Add("Tender Voided at " + DateTime.Now.ToString());
        Tenders.Clear();
    }
}
