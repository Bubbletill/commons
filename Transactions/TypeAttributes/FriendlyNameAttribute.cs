using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TypeAttributes;

public class FriendlyNameAttribute : Attribute
{
    public string Name { get; private set; }

    public FriendlyNameAttribute(string name)
    {
        Name = name;
    }
}
