using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.Attributes;

public class ExternalNameAttribute : Attribute
{
    public string Name { get; private set; }

    public ExternalNameAttribute(string name)
    {
        Name = name;
    }
}
