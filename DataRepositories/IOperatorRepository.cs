using BT_COMMONS.Operators;
using BT_COMMONS.Operators.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.DataRepositories;

public interface IOperatorRepository
{
    Task<Operator?> GetOperator(int id);
    Task<OperatorLoginResponse> OperatorLogin(OperatorLoginRequest request);
    Task<List<OperatorGroup>> GetOperatorGroups();
}
