namespace BT_COMMONS.Operators;

public class OperatorUpdate
{
    public bool IsActive { get; set; }

    public string OperatorId { get; set; }

    public string FirstName { get; set; }
    public string NickName { get; set; }
    public string LastName { get; set; }

    public List<int> ParsedGroupsId { get; set; }

    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime TerminationDate { get; set; }

}
