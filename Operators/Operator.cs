using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BT_COMMONS.Operators
{
    public class Operator
    {
        public int Id { private get; set; }
        public bool IsActive { get; set; }
        public bool IsTempPassword { get; set; }

        public string OperatorId { get; set; } = string.Empty;
        public string OperatorPassword { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string GroupsId { get; set; } = string.Empty;
        public List<int> _groupsId { get; set; } = new List<int>();
        public List<OperatorGroup> Groups { get; set; } = new List<OperatorGroup>();

        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public Operator()
        {
            parse();
        }

        public Operator parse()
        {
            if (GroupsId != null)
                _groupsId = JsonConvert.DeserializeObject<List<int>>(GroupsId);

            return this;
        }

    }
}
