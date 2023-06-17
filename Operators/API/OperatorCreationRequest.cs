namespace BT_COMMONS.Operators.API;

public class OperatorCreationRequest
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
