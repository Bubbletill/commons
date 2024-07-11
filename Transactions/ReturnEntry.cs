using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions;

public class ReturnEntry
{
    public int Urid { get; set; }
    public int Store { get; set; }
    public int Register { get; set; }
    public DateTime Date { get; set; }
    public int TransactionId { get; set; }
    public string Basket { get; set; }
    public List<BasketItem> ParsedBasket { get; set; }
    public bool Locked { get; set; }

    public ReturnEntry()
    {
        ParsedBasket = new List<BasketItem>();
    }

    public ReturnEntry(Transaction trxn)
    {
        Store = trxn.Store;
        Register = trxn.Register;
        Date = trxn.DateTime;
        TransactionId = trxn.TransactionId;
        Locked = true;

        ParsedBasket = new List<BasketItem>();
        List<BasketItem> preParsed = trxn.Basket;

        foreach (BasketItem item in preParsed)
        {
            for (int i = 0; i < item.Quantity; i++)
            {
                BasketItem newItem = item.Clone() as BasketItem;
                newItem.Quantity = 1;
                ParsedBasket.Add(newItem);
            }
        }
    }
}
