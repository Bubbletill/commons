using System;
using System.Reflection;

namespace BT_COMMONS.Transactions.TypeAttributes;

public static class TypeEnumExtensions
{

    public static bool GetReturnHome(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        ReturnHomeAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(ReturnHomeAttribute)
        ) as ReturnHomeAttribute;

        return Attribute.Home;
    }
}
