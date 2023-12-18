using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolTests;

public class TestBase
{
    protected List<Visitor> makeGenericGrouplessAdultVisitors(int Count)
    {
        List<Visitor> visitors = new List<Visitor>();
        for(int i = 0; i < Count; i++)
            visitors.Add(new Visitor()
            {
                age = 20,
                birthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                isNew = false,
                name = "Adult Visitor " + i,
                number = i,
                signDate = DateOnly.FromDateTime(DateTime.Now)
            });
        return visitors;
    }

    protected List<Visitor> makeGenericGrouplessChildVisitors(int Count)
    {
        List<Visitor> visitors = new List<Visitor>();
        for (int i = 0; i < Count; i++)
            visitors.Add(new Visitor()
            {
                age = 10,
                birthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                isNew = false,
                name = "Child Visitor " + i,
                number = i,
                signDate = DateOnly.FromDateTime(DateTime.Now)
            });
        return visitors;
    }

    protected List<Visitor> makeGenericGroupedAdultVisitors(int Count, int GroupNumber)
    {
        List<Visitor> visitors = new List<Visitor>();
        for (int i = 0; i < Count; i++)
            visitors.Add(new Visitor()
            {
                age = 20,
                birthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                isNew = false,
                name = "Adult Grouped Visitor " + i,
                number = i,
                signDate = DateOnly.FromDateTime(DateTime.Now),
                groupNumber = GroupNumber
            });
        return visitors;
    }

    protected List<Visitor> makeGenericGroupedChildVisitors(int Count, int GroupNumber)
    {
        List<Visitor> visitors = new List<Visitor>();
        for (int i = 0; i < Count; i++)
            visitors.Add(new Visitor()
            {
                age = 10,
                birthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                isNew = false,
                name = "Adult Grouped Visitor " + i,
                number = i,
                signDate = DateOnly.FromDateTime(DateTime.Now),
                groupNumber = GroupNumber
            });
        return visitors;
    }

    protected List<Visitor> MakeGenericGroupedMixedVisitors(int ChildCount, int AdultCount, int GroupNumber)
    {
        List<Visitor> visitors = new List<Visitor>();
        visitors.AddRange(makeGenericGroupedAdultVisitors(AdultCount, GroupNumber));
        visitors.AddRange(makeGenericGroupedChildVisitors(ChildCount, GroupNumber));
        return visitors;
    }

    protected List<Visitor> ChangeSignDate(List<Visitor> visitors, DateOnly newSignDate)
    {
        foreach (Visitor visitor in visitors)
        {
            visitor.signDate = newSignDate;
        }

        return visitors;
    }
}