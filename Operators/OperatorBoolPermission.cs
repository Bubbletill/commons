using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators
{
    public enum OperatorBoolPermission
    {
        POS_Access,

        POS_Return_Access,

        POS_ItemMod_Access,
        POS_ItemMod_ItemVoid,

        POS_TransMod_Access,
        POS_TransMod_TransVoid,

        BO_Access
    }
}
