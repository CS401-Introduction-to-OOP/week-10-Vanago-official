namespace week_10_Vanago_official;

class Program
{
    static void Main(string[] args)
    {
        Party party = new();
        EventLog eventLog = new();
        while (true)
        {
            Console.WriteLine("[1] Show all character");
            Console.WriteLine("[2] Add new character");
            Console.WriteLine("[3] Show event history");
            Console.WriteLine("[4] Add new event");
            Console.WriteLine("[5] Show statistic");
            Console.WriteLine("[0] Exit");
            Console.Write("\nOption: ");

            string? choice = Console.ReadLine();

            if (choice == "0") break;

            switch (choice)
            {
                case "1":
                    ShowAllCharacters(party);
                    break;
                case "2":
                    AddNewCharacter(party);
                    break;
                case "3":
                    ShowEventsHistory(eventLog);
                    break;
                case "4":
                    AddNewEvent(eventLog);
                    break;
                case "5":
                    ShowStatistics(party);
                    break;
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ShowAllCharacters(Party party)
    {
        foreach (var c in party)
        {
            Console.WriteLine(
                $"Name: {c.name}\nRole: {c.role}\nlvl: {c.level}\nHP: {c.GetHP()}\nGolf: {c.gold}\nStatus: {(c.isActive() ? "Active" : "Passive")}");
        }
    }

    static void AddNewCharacter(Party party)
    {
        try
        {
            Console.Write("name role lvl hp gold status(active/passive): ");
            string[] uInput = Console.ReadLine().Split(' ');
            
            if (uInput.Length != 6)
            {
                Console.WriteLine("need 6 parametrs");
                return;
            }
            
            string name = uInput[0];
            string role = uInput[1];
            int level = int.Parse(uInput[2]);
            int hp = int.Parse(uInput[3]);
            int gold = int.Parse(uInput[4]);
            Character.Status status = uInput[5] == "active" ? Character.Status.Active : Character.Status.Passive;

            party.Add(new Character(name, role, level, hp, gold, status));
            Console.WriteLine("added");
        }
        catch
        {
            Console.WriteLine("something wrong with ur request");
        }
    }

    static void ShowEventsHistory(EventLog eventLog)
    {
        Console.WriteLine("history:");
        var history = eventLog.GetEventInHistory().ToList();

        if (history.Count == 0)
        {
            Console.WriteLine("empty");
            return;
        }

        foreach (var item in history)
        {
            Console.WriteLine($"turn: {item.GetTurn()} | type: {item.GetTurnType()}");
        }
    }

    static void AddNewEvent(EventLog eventLog)
    {
        try
        {
            Console.Write("turn: ");
            int turn = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("description: ");
            string desc = Console.ReadLine() ?? "";

            Console.WriteLine("historical, another, simple, idk");
            Console.Write("choose one: ");
            Event.TurnType type = Enum.Parse<Event.TurnType>(Console.ReadLine());

            eventLog.AddEvent(new Event(turn, desc, type));
            Console.WriteLine("aded");
        }
        catch
        {
            Console.WriteLine("error.");
        }
    }

    static void ShowStatistics(Party party)
    {
        Console.WriteLine("statistic:");

        Console.WriteLine("lvl > 50:");
        var heroesupperlevel = party.Where(c => c.level > 50).OrderByDescending(c => c.GetHP());
        foreach (var item in heroesupperlevel)
        {
            Console.WriteLine($"{item.name}, lvl: {item.level}, hp: {item.GetHP()}");
        }

        Console.WriteLine("richest:");
        var richest = party.MaxBy(c => c.gold);
        if (richest != null) Console.WriteLine($"{richest.name} ({richest.gold} gold)");

        Console.WriteLine("hp < 100 count:");
        var trista = party.Count(c => c.GetHP() < 100);
        Console.WriteLine(trista);

        Console.WriteLine("grouped by role:");
        var groupedcharacters = party.GroupBy(c => c.role);
        foreach (var group in groupedcharacters)
        {
            Console.WriteLine($"role: {group.Key} (count: {group.Count()})");
            foreach (var hero in group)
            {
                Console.WriteLine($"  - {hero.name}");
            }
        }
    }
}