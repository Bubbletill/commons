using Newtonsoft.Json;

namespace BT_COMMONS.Operators;

public class OperatorGroup
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string BoolPermissions { get; set; }
    public string NumericalPermissions { get; set; }
    public List<OperatorBoolPermission> ParsedBoolPermissions { get; set; }
    public Dictionary<OperatorNumericalPermission, float> ParsedNumericalPermissions { get; set; }
    public bool Full { get; set; }

    public OperatorGroup()
    {
        
    }

    public void Parse()
    {
        if (BoolPermissions != null)
            ParsedBoolPermissions = JsonConvert.DeserializeObject<List<OperatorBoolPermission>>(BoolPermissions);
        
        if (NumericalPermissions != null)
            ParsedNumericalPermissions = JsonConvert.DeserializeObject<Dictionary<OperatorNumericalPermission, float>>(NumericalPermissions);
    }
}
