using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TenderAttributes;

public class InternalNameAttribute : Attribute
{
    public string Name { get; private set; }

    public InternalNameAttribute(string name)
    {
        Name = name;
    }
}
