using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions.TypeAttributes;

public class ReturnHomeAttribute : Attribute
{
    public bool Home { get; private set; }

    public ReturnHomeAttribute(bool home)
    {
        Home = home;
    }
}
