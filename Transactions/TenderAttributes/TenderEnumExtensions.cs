using System;
using System.Reflection;

namespace BT_COMMONS.Transactions.TenderAttributes;

public static class TenderEnumExtensions
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

    public static bool OpenCashDraw(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        OpenCashDrawAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(OpenCashDrawAttribute)
        ) as OpenCashDrawAttribute;

        return Attribute.Open;
    }

    public static bool ShowHigherTenderAmount(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        ShowHigherTenderAmountAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(ShowHigherTenderAmountAttribute)
        ) as ShowHigherTenderAmountAttribute;

        return Attribute.Show;
    }

    public static bool AllowHigherTender(this Enum Value)
    {
        Type Type = Value.GetType();

        FieldInfo FieldInfo = Type.GetField(Value.ToString());

        AllowHigherTenderAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(AllowHigherTenderAttribute)
        ) as AllowHigherTenderAttribute;

        return Attribute.Allow;
    }
}
