using BT_COMMONS.Transactions.TenderAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionTender
{
    [InternalName("Cash"), ExternalName("Cash"), OpenCashDraw(true), ShowHigherTenderAmount(true), AllowHigherTender(true)]
    CASH,

    [InternalName("External Card"), ExternalName("EX Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false)]
    EXTERNAL_CARD,

    [InternalName("Worldpay Card"), ExternalName("WP Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false)]
    WORLDPAY_CARD,

    [InternalName("Square Card"), ExternalName("SQ Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false)]
    SQUARE_CARD
}
