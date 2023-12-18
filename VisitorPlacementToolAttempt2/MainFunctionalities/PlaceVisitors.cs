using VisitorPlacementToolAttempt2.DataStorages;

namespace VisitorPlacementToolAttempt2.MainFunctionalities;

public class PlaceVisitors
{
    //TODO place all visitors and fill the fields entirely for first attempt
    public Event FillFields(Event eEvent)
    {
        for (int i = 0; i < eEvent.Visitors.Count; i++)
        {
            bool placed = false;
            for (int fieldIndex = 0; fieldIndex < eEvent.Fields.Count; fieldIndex++)
            {
                if (!placed)
                {
                    for (int rowIndex = 0; rowIndex < eEvent.Fields[fieldIndex].Rows.Count; rowIndex++)
                    {
                        if (!placed)
                        {
                            for (int visitorIndex = 0;
                         visitorIndex < eEvent.Fields[fieldIndex].Rows[rowIndex].Visitors.Count;
                         visitorIndex++)
                            {
                                if (!placed)
                                {
                                    eEvent.Fields[fieldIndex].Rows[rowIndex].Visitors[visitorIndex] = eEvent.Visitors[0];
                                    eEvent.Visitors.RemoveAt(0);
                                    placed = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return eEvent;
    }

    //TODO check sign-up dates for second attempt
    public Event CheckSignUpDates(Event eEvent)
    {
        return eEvent;
    }

    //TODO check ages at time of event for third attempt
    public Event CheckAgesAtTimeOfEvent(Event eEvent)
    {
        return eEvent;
    }

    //TODO place groups that fit immediately, drop the rest
    public Event PlaceGroups(Event eEvent)
    {
        return eEvent;
    }

    //TODO place children in the front for fourth attempt
    public Event PlaceChildrenInFront(Event eEvent)
    {
        return eEvent;
    }

    //TODO place children in rows with associated adults for fifth attempt
    public Event PlaceChildrenWithAdults(Event eEvent)
    {
        return eEvent;
    }

    //TODO split groups that don't fit and place the split groups
    public Event SplitGroupsThatDoNotFit(Event eEvent)
    {
        return BinPackingAlgorithmHolder_So_I_Dont_Forget_.SplitLargeGroups(eEvent);
    }

}