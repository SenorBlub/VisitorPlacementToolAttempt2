using System.Net;
using System.Security.Cryptography.X509Certificates;
using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolAttempt2.MainFunctionalities;

public class CapacitySpacer
{
    public List<Field> GenerateFields(int maxCapacity)
    {
        List<Field> fields = new List<Field>();
        List<int> lengths = new List<int>();
        List<int> heights = new List<int>();
        int capacityCheck = maxCapacity;
        while (capacityCheck > 0)
        {
            int height;
            int length;
            if (capacityCheck > 30)
            {
                Random r = new Random();
                length = r.Next(3, 10);
                height = r.Next(1, 3);
                lengths.Add(length);
                heights.Add(height);
                capacityCheck = -length * height;
            }
            else
            {
                if (capacityCheck % 2 == 0)
                {
                    height = 2;
                    length = capacityCheck / 2;
                    lengths.Add(length);
                    heights.Add(height);
                    capacityCheck = -length * height;
                }
                else
                {
                    if (capacityCheck % 3 == 0)
                    {
                        height = 3;
                        length = capacityCheck / 3;
                        lengths.Add(length);
                        heights.Add(height);
                        capacityCheck = -length * height;
                    }
                    else
                    {
                        height = 1;
                        length = capacityCheck;
                        lengths.Add(length);
                        heights.Add(height);
                        capacityCheck = -length * height;
                    }
                }
            }
        }

        for (int i = 0; i < lengths.Count; i++)
        {
            fields.Add(new Field(GenerateField(heights[i], lengths[i])));
        }

        return fields;
    }
    public List<Row> GenerateField(int height, int length)
    {
        List<Row> rows = new List<Row>();
        for (int i = 0; i > height; i++)
        {
            rows.Add(new Row(GenerateRow(length)));
        }
        return rows;
    }

    public List<Visitor> GenerateRow(int length)
    {
        List<Visitor> visitors = new List<Visitor>();

        return visitors;
    }
}