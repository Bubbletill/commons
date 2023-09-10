using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators.PermissionAttributes;

public class PermissionPromptNameAttribute : Attribute
{
    public string Name { get; private set; }

    public PermissionPromptNameAttribute(string name)
    {
        Name = name;
    }
}
