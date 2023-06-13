using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators
{
    public class OperatorCreation
    {
        public string OperatorId { get; set; }
        public string OperatorPasswordPlain { get; set; }

        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }

        public List<int> Groups { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
