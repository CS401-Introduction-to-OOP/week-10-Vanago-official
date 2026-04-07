using System.Collections;

namespace week_10_Vanago_official;

public class Party : IEnumerable<Character>
{
    private List<Character> characters = new();

    public void Add(Character character)
    {
        characters.Add(character);
    }
    
    public IEnumerator<Character> GetEnumerator()
    {
        return characters.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public IEnumerable<Character> GetActiveCharacters()
    {
        foreach (var character in characters)
        {
            if (character.isActive()) yield return character;
        }
    }

    public IEnumerable<Character> GetCharacterWithHPLowerThan(int hp)
    {
        foreach (var character in characters)
        {
            if (character.GetHP() < hp)
            {
                yield return character;
            }
        }
    }
}