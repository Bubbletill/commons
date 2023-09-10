using BT_COMMONS.Transactions.TenderAttributes;
using System;
using System.Reflection;

namespace BT_COMMONS.Operators.PermissionAttributes;

public static class OperatortPermissionEnumExtension
{
    public static string GetPromptName(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        PermissionPromptNameAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(PermissionPromptNameAttribute)
        ) as PermissionPromptNameAttribute;

        return Attribute.Name;
    }
}
