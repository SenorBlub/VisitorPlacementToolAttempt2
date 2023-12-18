namespace VisitorPlacementToolAttempt2.DataStorages;

public class Row
{
    public List<Visitor> Visitors { get; set; }

    public Row(List<Visitor> visitors)
    {
        Visitors = visitors;
    }
}