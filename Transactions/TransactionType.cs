using BT_COMMONS.Transactions.TenderAttributes;
using BT_COMMONS.Transactions.TypeAttributes;

namespace BT_COMMONS.Transactions;

public enum TransactionType
{
    // 0xx = Customer facing transactions
    [ReturnHome(true), OpenCashDraw(false)]
    SALE = 0,
    [ReturnHome(true), OpenCashDraw(false)]
    RETURN = 1,
    [ReturnHome(true), OpenCashDraw(false)]
    EXCHANGE = 2,

    // 1xx = Semi-customer facing, none administrative transactions
    [ReturnHome(true), OpenCashDraw(false)]
    SUSPEND = 100,
    [ReturnHome(true), OpenCashDraw(false)]
    RESUME = 101,
    [ReturnHome(true), OpenCashDraw(false)]
    GIFT_RECEIPT = 102,

    // 2xx = Administrative actions
    [ReturnHome(true), OpenCashDraw(true)]
    NO_SALE = 200,

    [ReturnHome(false), OpenCashDraw(false)]
    REGISTER_OPEN = 201,
    [ReturnHome(true), OpenCashDraw(true)]
    REGISTER_CLOSE = 202,
    [ReturnHome(true), OpenCashDraw(false)]
    X_READ = 203,
    [ReturnHome(true), OpenCashDraw(true)]
    LOAN = 204,

    [ReturnHome(true), OpenCashDraw(false)]
    RECEIPT_REPRINT = 210,

    [ReturnHome(true), OpenCashDraw(false)]
    TRAINING_ON = 211,
    [ReturnHome(true), OpenCashDraw(false)]
    TRAINING_OFF = 212,
    [ReturnHome(true), OpenCashDraw(false)]
    TRAINING_TRANS = 213,

    // 9xx = Voids
    [ReturnHome(true), OpenCashDraw(false)]
    POST_VOID = 998,
    [ReturnHome(true), OpenCashDraw(false)]
    VOID = 999

}
