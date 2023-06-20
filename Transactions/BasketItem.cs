﻿namespace BT_COMMONS.Transactions;

public class BasketItem
{
    public int Code { get; set; }
    public string Description { get; set; }

    public float FilePrice { get; set; }
    public float SalePrice { get; set; }
    public float ReductionAmount { get; set; } = 0;
    public ReductionReason ReductionReason { get; set; } = ReductionReason.NONE;

    public int Quantity { get; set; } = 1;

    public bool Refund { get; set; } = false;

    public bool Returned { get; set; } = false;

    public BasketItem()
    {
        Description = "Not Set";
    }
}
