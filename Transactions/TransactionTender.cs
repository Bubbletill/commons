using BT_COMMONS.Transactions.TenderAttributes;
using BT_COMMONS.Transactions.TypeAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionTender
{
    [InternalName("Cash"), ExternalName("Cash"), OpenCashDraw(true), ShowHigherTenderAmount(true), AllowHigherTender(true), CanPostVoid(true)]
    CASH,

    [InternalName("External Card"), ExternalName("EX Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false), CanPostVoid(true)]
    EXTERNAL_CARD,

    [InternalName("Worldpay Card"), ExternalName("WP Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false), CanPostVoid(false)]
    WORLDPAY_CARD,

    [InternalName("Square Card"), ExternalName("SQ Card"), OpenCashDraw(false), ShowHigherTenderAmount(false), AllowHigherTender(false), CanPostVoid(false)]
    SQUARE_CARD
}
