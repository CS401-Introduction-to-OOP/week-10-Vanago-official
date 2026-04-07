namespace week_10_Vanago_official;

class Program
{
    static void Main(string[] args)
    {
        Party party = new();
        EventLog eventLog = new();
        
        party.Add(new Character("Adolf", "tank", 43, 60, 488, Character.Status.Active));
        party.Add(new Character("Elizaveta", "healer", 67, 67, 1234, Character.Status.Passive));
        
        eventLog.AddEvent(new Event(25, "heat someone", Event.TurnType.idk));
        eventLog.AddEvent(new Event(26, "something happened", Event.TurnType.another));
        eventLog.AddEvent(new Event(12, "someone", Event.TurnType.historical));
        
        var heroesupperlevel = party.Where(c => c.level > 50).OrderByDescending(c => c.GetHP());
        foreach (var item in heroesupperlevel)
        {
            Console.WriteLine($"{item.name}, {item.level}");
        }

        Console.WriteLine(party.MaxBy(c => c.gold));

        var trista = party.Count(c => c.GetHP()<100);
        Console.WriteLine(trista);

        var groupedcharacters = party.GroupBy(c => c.role);
        foreach (var item in groupedcharacters)
        {
            Console.WriteLine(item.Key);
        }
    }
}