using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TenderAttributes;

public class OpenCashDrawAttribute : Attribute
{
    public bool Open { get; private set; }

    public OpenCashDrawAttribute(bool open)
    {
        Open = open;
    }
}
