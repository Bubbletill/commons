﻿using BT_COMMONS.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.DataRepositories;

public interface ISuspendRepository
{
    Task<bool> Suspend(Transaction transaction);
    Task<List<SuspendEntry>?> List(int store);
    Task<bool> Delete(int suspendId);
}
