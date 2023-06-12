using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators
{
    public class OperatorGroup
    {
        public string Name { get; set; }
        public int GroupLevel { get; set; }
        public Dictionary<OperatorBoolPermission, bool> BoolPermissions { get; set; }
        public Dictionary<OperatorNumericalPermission, float> NumericalPermissions { get; set; }

        public OperatorGroup()
        {
            BoolPermissions = new Dictionary<OperatorBoolPermission, bool>();
            NumericalPermissions = new Dictionary<OperatorNumericalPermission, float>();
        }
    }
}
