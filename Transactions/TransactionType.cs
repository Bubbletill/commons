using BT_COMMONS.Transactions.TenderAttributes;
using BT_COMMONS.Transactions.TypeAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionType
{
    // 0xx = Customer facing transactions
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Sale"), ShowOnXRead(true)]
    SALE = 0,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Return"), ShowOnXRead(true)]
    RETURN = 1,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Exchange"), ShowOnXRead(true)]
    EXCHANGE = 2,

    // 1xx = Semi-customer facing, none administrative transactions
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Suspend"), ShowOnXRead(false)]
    SUSPEND = 100,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Resume"), ShowOnXRead(false)]
    RESUME = 101,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Gift Receipt Print"), ShowOnXRead(false)]
    GIFT_RECEIPT = 102,

    // 2xx = Administrative actions
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("No Sale"), ShowOnXRead(true)]
    NO_SALE = 200,

    [ReturnHome(false), OpenCashDraw(false), CanReturn(false), FriendlyName("Register Open"), ShowOnXRead(false)]
    REGISTER_OPEN = 201,
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("Register Close"), ShowOnXRead(false)]
    REGISTER_CLOSE = 202,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("X Read"), ShowOnXRead(false)]
    X_READ = 203,
    [ReturnHome(true), OpenCashDraw(true), CanReturn(false), FriendlyName("Loan"), ShowOnXRead(true)]
    LOAN = 204,

    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Receipt Reprint"), ShowOnXRead(false)]
    RECEIPT_REPRINT = 210,

    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Training On"), ShowOnXRead(false)]
    TRAINING_ON = 211,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Training Off"), ShowOnXRead(false)]
    TRAINING_OFF = 212,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(true), FriendlyName("Training Transaction"), ShowOnXRead(true)]
    TRAINING_TRANS = 213,

    // 9xx = Voids
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Post Void"), ShowOnXRead(true)]
    POST_VOID = 998,
    [ReturnHome(true), OpenCashDraw(false), CanReturn(false), FriendlyName("Void"), ShowOnXRead(true)]
    VOID = 999

}
