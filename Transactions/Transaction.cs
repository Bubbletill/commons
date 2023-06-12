﻿namespace BT_COMMONS.Transactions
{
    public class Transaction
    {
        public int Store { get; set; }
        public int Register { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int Trans { get; set; }
        public TransactionType Type { get; set; }
        public int Oper { get; set; }
        public List<BasketItem> Basket { get; set; }

        public Transaction()
        {
            Basket = new List<BasketItem>();
        }

        public float GetSubTotal()
        {
            float total = 0;
            Basket.ForEach(item => { total += item.FilePrice; });
            return total;
        }

        public float GetTotal()
        {
            float total = 0;
            Basket.ForEach(item => { total += item.SalePrice; });
            return total;
        }
    }
}