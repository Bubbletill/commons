namespace BT_COMMONS.Transactions
{
    public class BasketItem
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public float FilePrice { get; set; }
        public float SalePrice { get; set; }
        public float ReductionAmount { get; set; }
        public ReductionReason ReductionReason { get; set; }

        public int Quantity { get; set; }

        public bool Refund { get; set; }

        public Dictionary<TransactionTender, float> Tenders { get; set; }

        public BasketItem()
        {
            Description = "Not Set";
            Tenders = new Dictionary<TransactionTender, float>();
        }
    }
}
