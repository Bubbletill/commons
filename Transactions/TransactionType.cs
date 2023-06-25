namespace BT_COMMONS.Transactions;

public enum TransactionType
{
    // 0xx = Customer facing transactions
    SALE = 0,
    RETURN = 1,
    EXCHANGE = 2,

    // 1xx = Semi-customer facing, none administrative transactions
    SUSPEND = 100,
    RESUME = 101,
    GIFT_RECEIPT = 102,

    // 2xx = Administrative actions
    NO_SALE = 200,

    REGISTER_OPEN = 201,
    REGISTER_CLOSE = 202,
    X_READ = 203,
    LOAN = 204,

    RECEIPT_REPRINT = 210,

    // 9xx = Voids
    POST_VOID = 998,
    VOID = 999

}
