using BT_COMMONS.Transactions.Attributes;
using System;
using System.Reflection;

namespace BT_COMMONS.Helpers;

public static class EnumExtensions
{
    public static string GetTenderInternalName(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        InternalNameAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(InternalNameAttribute)
        ) as InternalNameAttribute;

        return Attribute.Name;
    }

    public static string GetTenderExternalName(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        ExternalNameAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(ExternalNameAttribute)
        ) as ExternalNameAttribute;

        return Attribute.Name;
    }
}
