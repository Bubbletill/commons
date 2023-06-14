using BT_COMMONS.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.DataRepositories
{
    public interface IOperatorRepository
    {
        Operator GetOperator(int id);
        OperatorLoginResponse OperatorLogin(OperatorLoginRequest request);
    }
}
