using System.Net;

namespace VisitorPlacementToolAttempt2.DataStorages;

public class Field
{
    public List<Row> Rows { get; set; }

    public Field(List<Row> rows)
    {
        Rows = rows;
        //TODO make fields with random sizes within the maximum capacity
    }
}