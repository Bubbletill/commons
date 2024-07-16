using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TypeAttributes;

public class CanPostVoidAttribute : Attribute
{
    public bool Allow { get; private set; }

    public CanPostVoidAttribute(bool allow)
    {
        Allow = allow;
    }
}
