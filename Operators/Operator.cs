using Newtonsoft.Json;

namespace BT_COMMONS.Operators;

public class Operator
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsTempPassword { get; set; }

    public string OperatorId { get; set; } = string.Empty;
    public string OperatorPassword { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string GroupsId { get; set; } = string.Empty;
    public List<int> ParsedGroupsId { get; set; } = new List<int>();
    public List<OperatorGroup> Groups { get; set; } = new List<OperatorGroup>();

    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime TerminationDate { get; set; }

    public Operator Parse(Dictionary<int, OperatorGroup> operGroups)
    {
        if (GroupsId != null)
            ParsedGroupsId = JsonConvert.DeserializeObject<List<int>>(GroupsId);

        foreach (var group in ParsedGroupsId)
        {
            Groups.Add(operGroups[group]);
        }

        return this;
    }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }

    public string ReducedName()
    {
        return FirstName[0] + " " + LastName;
    }

    public string Name()
    {
        if (NickName != null && NickName != string.Empty)
            return NickName;
        else
            return FirstName;
    }

    public bool HasBoolPermission(OperatorBoolPermission? permission)
    {
        if (permission == null)
            return true;

        foreach (OperatorGroup group in Groups)
        {
            if (group.Full)
                return true;

            if (group.ParsedBoolPermissions.Contains((OperatorBoolPermission)permission))
                return true;
        }

        return false;
    }

    public List<float> GetNumericalPermissions(OperatorNumericalPermission permission)
    {
        List<float> toReturn = new List<float>();
        foreach (OperatorGroup group in Groups)
        {
            toReturn.Add(group.ParsedNumericalPermissions.GetValueOrDefault(permission, -1f));
        }

        return toReturn;
    }

}
