namespace week_10_Vanago_official;

public class EventLog
{
    private List<Event> events = new();

    public void AddEvent(Event item)
    {
        events.Add(item);
    }
    
    public IEnumerable<Event> GetEventInHistory()
    {
        int maxTurn = 0;
        foreach (var item in events)
        {
            if (item.GetTurn() > maxTurn)
            {
                maxTurn = item.GetTurn();
                yield return item;
            }
        }
    }

    public IEnumerable<Event> TypeEvents(Event.TurnType type)
    {
        foreach (var item in events)
        {
            if (item.GetTurnType() == type)
            {
                yield return item;
            }
        }
    }
}