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
    Task<Transaction?> GetTransaction(int store, int register, int transId, DateOnly date);

    Task<ReturnEntry?> GetReturnEntry(int store, int register, int transId, DateOnly date);
    Task<ReturnEntry?> GetReturnEntry(int urid);
    Task<int> SubmitReturnEntry(ReturnEntry entry);
    Task<bool> UpdateReturnEntry(ReturnEntry entry);
    Task<bool> ToggleReturnLock(int urid, bool locked);
}
