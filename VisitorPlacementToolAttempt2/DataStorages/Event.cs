using VisitorPlacementToolAttempt2.MainFunctionalities;

namespace VisitorPlacementToolAttempt2.DataStorages;

public class Event
{
    public List<Field> Fields { get; set; }
    public int MaximumCapacity { get; set; }
    public DateTime Date { get; set; }
    public DateTime SignUpDeadline { get; set; }

    public Event(List<Field> fields, int maximumCapacity, DateTime date, DateTime signUpDeadline)
    {
        Fields = new CapacitySpacer().GenerateFields(maximumCapacity);
        this.MaximumCapacity = maximumCapacity;
        this.Date = date;
        SignUpDeadline = signUpDeadline;
    }
}