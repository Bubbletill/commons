using BT_COMMONS.Transactions.Attributes;

namespace BT_COMMONS.Transactions;

public enum TransactionTender
{
    [InternalName("Cash"), ExternalName("Cash")]
    CASH,

    [InternalName("External Card"), ExternalName("Card")]
    EXTERNAL_CARD


}
