using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolAttempt2.MainFunctionalities;

//TODO remainderer is broken and needs to be fixed for algo to work
public static class BinPackingAlgorithmHolder_So_I_Dont_Forget_
{
    public static Event SplitLargeGroups(Event eEvent)
    {

        //TODO find the groups of visitors :check:
        Dictionary<int, List<Visitor>> visitorsDictionary = new Dictionary<int, List<Visitor>>();//groups
        for (int i = 0; i < eEvent.Visitors.Count; i++)
        {
            if (visitorsDictionary.ContainsKey((int)eEvent.Visitors[i].groupNumber))
            {
                visitorsDictionary[(int)eEvent.Visitors[i].groupNumber].Add(eEvent.Visitors[i]);
            }
            else
            {
                visitorsDictionary.Add((int)eEvent.Visitors[i].groupNumber, new List<Visitor>()
                {
                    eEvent.Visitors[i]
                });
            }
        }

        //TODO find the values to squeeze into :check:
        Dictionary<KeyValuePair<int, int>, int> rowSizes = new Dictionary<KeyValuePair<int, int>, int>();
        Dictionary<int, KeyValuePair<int, int>> indexConverter = new Dictionary<int, KeyValuePair<int, int>>();

        int indexer = 0;
        for (int fieldIndex = 0; fieldIndex < eEvent.Fields.Count; fieldIndex++)
        {
            for (int rowIndex = 0; rowIndex < eEvent.Fields[fieldIndex].Rows.Count; rowIndex++)
            {
                var key = new KeyValuePair<int, int>(fieldIndex, rowIndex);
                rowSizes.Add(key, eEvent.Fields[fieldIndex].Rows[rowIndex].Visitors.Count);
                indexConverter.Add(indexer, key);
                indexer++;
            }
        }

        //TODO do the MATHSSSSSS
        Dictionary<int, Visitor> visitorPlacementLocationDictionary = new Dictionary<int, Visitor>();
        //TODO eventual end solution lies in using divisibility by different small factors with every divisible of end result adding a point, higher weight is better

        //TODO basic math values are currently saved under: visitorsDictionary.value[x].Count and rowSizes, end goal is fit rowSizes into vD.v[x].C until none can be fit
        //TODO from that point onward change functionality to fit remainders into as few spots as possible

        //KeyValuePair<int, Visitor>;

        List<int> groupPlaces = new List<int>(); // TODO this has got the right idea but not quite functional
        foreach (KeyValuePair<int, List<Visitor>> group in visitorsDictionary)
        {
            int bestOptionIndex = -1;
            int bestOptionScore = int.MinValue;

            for (int i = 0; i < rowSizes.Count; i++)
            {
                int potentialScore = DivisibilityScore(group.Value.Count - rowSizes[indexConverter[i]]);

                if (potentialScore > bestOptionScore)
                {
                    bestOptionScore = potentialScore;
                    bestOptionIndex = i;
                }
            }

            if (bestOptionIndex != -1)
            {
                if (group.Value.Count > rowSizes[indexConverter[bestOptionIndex]])
                {
                    List<Visitor> sGroup = visitorsDictionary[group.Key];
                    int remainingSize = group.Value.Count;
                    int rowIndex = bestOptionIndex;
                    while (remainingSize > 0)
                    {
                        if (rowIndex >= rowSizes.Count)
                        {
                            List<Visitor> remainingVisitors = Remainderer(sGroup, rowSizes.Values.ToList());
                        }
                        else
                        {
                            int rowCapacity = rowSizes[indexConverter[rowIndex]];
                            int groupToAdd = Math.Min(remainingSize, rowCapacity);
                            eEvent.Fields[indexConverter[rowIndex].Key].Rows[indexConverter[rowIndex].Value].Visitors
                                .AddRange(sGroup.GetRange(0, groupToAdd));
                            sGroup.RemoveRange(0, groupToAdd);
                            remainingSize -= groupToAdd;
                            rowIndex++;
                        }
                    }
                }
                else
                {
                    eEvent.Fields[indexConverter[bestOptionIndex].Key].Rows[indexConverter[bestOptionIndex].Value].Visitors.AddRange(visitorsDictionary[group.Key]);
                }

                rowSizes.Remove(indexConverter[bestOptionIndex]);
            }
        }

        return eEvent;
    }

    //Method used to check the score->weight of a certain outcome value
    public static int DivisibilityScore(int inputNumber)
    {
        int points = 0;
        for (int i = 1; i < 10; i++)
        {
            if (inputNumber % i == 0)
                points++;
        }
        return points;
    }

    public static List<Visitor> Remainderer(List<Visitor> group, List<int> remainingSpaces)
    {
        List<Visitor> remainingVisitors = new List<Visitor>();

        for (int i = 0; i < remainingSpaces.Count; i++)
        {
            int remainingSpace = remainingSpaces[i];

            if (remainingSpace > 0 && group.Count > 0)
            {
                int groupToAdd = Math.Min(group.Count, remainingSpace);
                remainingVisitors.AddRange(group.GetRange(0, groupToAdd));
                group.RemoveRange(0, groupToAdd);
                remainingSpaces[i] -= groupToAdd;
            }
        }

        return remainingVisitors;
    }

}