namespace BT_COMMONS.Transactions;

public class BasketItem
{
    public int Code { get; set; }
    public string Description { get; set; } = "Not Set";
    public float FilePrice { get; set; }
    public float SalePrice
    {
        get
        {
            return (FilePrice * Quantity) - ReductionAmount;
        }

        private set
        {

        }
    }

    public bool AgeRestricted { get; set; }
    
    public float ReductionAmount { get; set; } = 0;
    public ReductionReason ReductionReason { get; set; } = ReductionReason.NONE;

    public int Quantity { get; set; } = 1;

    public bool Refund { get; set; } = false;

    public bool Returned { get; set; } = false;

    public BasketItem(int code, string description, float filePrice, bool ageRestricted)
    {
        Code = code;
        Description = description;
        FilePrice = filePrice;
        AgeRestricted = ageRestricted;
    }

    public BasketItem() { }
}
