namespace week_10_Vanago_official;

public class Event
{
    private int turn;
    private string description;
    private TurnType turnType;

    public Event(int Turn, string Description, TurnType TurnType)
    {
        turn = Turn;
        description = Description;
        turnType = TurnType;
    }

    public int GetTurn()
    {
        return turn;
    }

    public TurnType GetTurnType()
    {
        return turnType;
    } 
        
    public enum TurnType
    {
        historical,
        another,
        simple,
        idk
    }

    public override string ToString()
    {
        return $"{turn}";
    }
}