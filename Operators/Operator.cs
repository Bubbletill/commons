using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators
{
    public class Operator
    {
        public bool IsActive { get; set; }

        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }

        public List<OperatorGroup> Groups { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public DateOnly HireDate { get; set; }
        public DateOnly TerminationDate { get; set; }

    }
}
