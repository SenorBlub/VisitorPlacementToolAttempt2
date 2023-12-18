using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolAttempt2.StartingDataGenerators;

public class PeopleGenerator
{
    public static List<Visitor> GenerateVisitors(int Amount, int GroupCount)
    {
        List<Visitor> visitors = new List<Visitor>();

        for (int i = 0; i < Amount; i++)
        {
            int age = new Random().Next(40);
            int? group = null;
            if (i % new Random().Next(3, 7) == 0)
                group = new Random().Next(GroupCount);
            visitors.Add(
                new Visitor
                {
                    age = age,
                    birthDate = DateOnly.FromDateTime(
                        DateTime.Now - TimeSpan.FromDays(365 * age)
                        + TimeSpan.FromDays(new Random().Next(365))),
                    groupNumber = group,
                    isNew = i % Amount == 0,
                    name = NameGenerator.Name(),
                    number = i,
                    signDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-new Random().Next(30)))
                }
            );
        }
        return visitors;
    }
}