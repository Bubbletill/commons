using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TenderAttributes;

public class ShowHigherTenderAmountAttribute : Attribute
{
    public bool Show { get; private set; }

    public ShowHigherTenderAmountAttribute(bool show)
    {
        Show = show;
    }
}
