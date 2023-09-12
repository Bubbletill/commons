using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Transactions;

public enum TransactionLogType
{
    Hidden = 0,               // Never shown to customer, can be seen on Back Office
    Invisible = 1,            // Never shown to customer or on Back Office, only for Head Office
    NSGeneral = 2,            // Hidden if a transaction's receipt is intended to be given to the customer

    PreSubTotal = 3,          // Shown before the sub total
    PreTotal = 4,             // Shown before the total
    TransactionDiscount = 5,  // Shown before the total, must be related to transaction discounts

    PreTender = 6,            // Shown before the tenders
    Tender = 7,               // The tenders used
    PostTender = 8            // Shown after the tenders used
}
