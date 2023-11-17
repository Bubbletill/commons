using BT_COMMONS.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.DataRepositories;

public interface ITransactionRepository
{
    Task<int?> GetPreviousTransactionId(int store, int register);
    Task<bool> SubmitTransaction(Transaction transaction, TransactionType? postTrans = null);
}
