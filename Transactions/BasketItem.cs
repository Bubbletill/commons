namespace BT_COMMONS.Transactions;

public class BasketItem : ICloneable
{
    public int Code { get; set; }
    public string Description { get; set; } = "Not Set";
    public float FilePrice { get; set; }
    public float SalePrice
    {
        get
        {
            if (Refund)
                return (-FilePrice * Quantity) + ReductionAmount;
            else
                return (FilePrice * Quantity) - ReductionAmount;
        }

        private set
        {

        }
    }

    public int AgeRestricted { get; set; }
    
    public float ReductionAmount { get; set; } = 0;
    public ReductionReason ReductionReason { get; set; } = ReductionReason.NONE;

    public int Quantity { get; set; } = 1;

    public bool Refund { get; set; } = false;
    public bool Returned { get; set; } = false;
    public int PartOfReturnId { get; set; } = 0;

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public BasketItem(int code, string description, float filePrice, int ageRestricted)
    {
        Code = code;
        Description = description;
        FilePrice = filePrice;
        AgeRestricted = ageRestricted;
    }

    public BasketItem() { }
}
