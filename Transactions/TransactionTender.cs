using BT_COMMONS.Transactions.TenderAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionTender
{
    [InternalName("Cash"), ExternalName("Cash"), OpenCashDraw(true), ShowHigherTenderAmount(true), AllowHigherTender(true)]
    CASH,

    [InternalName("External Card"), ExternalName("Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false)]
    EXTERNAL_CARD


}
