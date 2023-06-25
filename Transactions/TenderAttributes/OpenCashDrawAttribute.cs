using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TenderAttributes;

public class AllowHigherTenderAttribute : Attribute
{
    public bool Allow { get; private set; }

    public AllowHigherTenderAttribute(bool allow)
    {
        Allow = allow;
    }
}
