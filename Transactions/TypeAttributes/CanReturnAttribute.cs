using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TypeAttributes;

public class CanReturnAttribute : Attribute
{
    public bool Allow { get; private set; }

    public CanReturnAttribute(bool allow)
    {
        Allow = allow;
    }
}
