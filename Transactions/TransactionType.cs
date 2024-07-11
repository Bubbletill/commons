using BT_COMMONS.Transactions.TenderAttributes;
using BT_COMMONS.Transactions.TypeAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionType
{
    // 0xx = Customer facing transactions
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Sale")]
    SALE = 0,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Return")]
    RETURN = 1,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Exchange")]
    EXCHANGE = 2,

    // 1xx = Semi-customer facing, none administrative transactions
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Suspend")]
    SUSPEND = 100,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Resume")]
    RESUME = 101,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Gift Receipt Print")]
    GIFT_RECEIPT = 102,

    // 2xx = Administrative actions
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("No Sale")]
    NO_SALE = 200,

    [ReturnHome(false), OpenCashDraw(false), CanReturn(false), FriendlyName("Register Open")]
    REGISTER_OPEN = 201,
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("Register Close")]
    REGISTER_CLOSE = 202,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("X Read")]
    X_READ = 203,
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("Loan")]
    LOAN = 204,

    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Receipt Reprint")]
    RECEIPT_REPRINT = 210,

    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Training On")]
    TRAINING_ON = 211,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Training Off")]
    TRAINING_OFF = 212,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Training Transaction")]
    TRAINING_TRANS = 213,

    // 9xx = Voids
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Post Void")]
    POST_VOID = 998,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Void")]
    VOID = 999

}
