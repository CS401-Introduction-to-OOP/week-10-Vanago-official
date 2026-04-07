namespace week_10_Vanago_official;

public class Character
{
    public string name { get; private init; }
    public string role { get; private set; }
    public int level { get; private set; }
    private int health;
    public int gold { get; private set; }
    private Status status;

    public Character(string Name, string Role, int Level, int Health, int Gold, Status Status)
    {
        name = Name;
        role = Role;
        level = Level;
        health = Health;
        gold = Gold;
        status = Status;
    }

    public int GetHP()
    {
        return health;
    }
    
    public enum Status
    {
        Active,
        Passive
    }

    public bool isActive()
    {
        return status == Status.Active;
    }

    public override string ToString()
    {
        return name;
    }
}


