using BT_COMMONS.Transactions.TenderAttributes;
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

    public static bool CanReturn(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        CanReturnAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(CanReturnAttribute)
        ) as CanReturnAttribute;

        return Attribute.Allow;
    }

    public static string FriendlyName(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        FriendlyNameAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(FriendlyNameAttribute)
        ) as FriendlyNameAttribute;

        return Attribute.Name;
    }

    public static bool ShowOnXRead(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        ShowOnXRead Attribute = FieldInfo.GetCustomAttribute(
            typeof(ShowOnXRead)
        ) as ShowOnXRead;

        return Attribute.Show;
    }
}
