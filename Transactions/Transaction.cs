﻿namespace BT_COMMONS.Transactions;

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

    public TransactionType PostTransType { get; set; }

    public Transaction()
    {
        Basket = new List<BasketItem>();
    }

    public void Init(int store, int register, DateOnly date, TimeOnly time, int transid, TransactionType type)
    {
        Store = store;
        Register = register;
        Date = date;
        Time = time;
        TransactionId = transid;
        Type = type;
    }

    public void AddToBasket(BasketItem item)
    {
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
}
