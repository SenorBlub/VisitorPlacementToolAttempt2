using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolAttempt2.StartingDataGenerators;

public class NameGenerator
{
    public static string Name()
    {
        string name = "";

        name += new Names().first[new Random(DateTime.Now.Millisecond).Next(new Names().first.Count)].ToString();
        name += " ";
        name += new Names().last[new Random(DateTime.Now.Millisecond).Next(new Names().last.Count)].ToString();

        return name;
    }
}