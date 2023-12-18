namespace VisitorPlacementToolAttempt2.DataStorages;

public class Visitor
{
    public int number { get; set; }
    public bool group { get; } = false;

    public string name { get; set; }

    public DateOnly birthDate { get; set; }

    public int age { get; set; }

    public int? groupNumber { get; set; }

    public DateOnly signDate { get; set; }

    public bool isNew { get; set; }
}