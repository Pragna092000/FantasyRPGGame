using System;

class Program
{
    private static int result;

    static void Main()
    {
        int numberOfDuels = 100;
        int humanWins = 0, balrogWins = 0, ties = 0;

        for (int i = 0; i < numberOfDuels; i++)
        {
            Creature human = new Creature("Human", 50, 100);
            Creature balrog = new Creature("Balrog", 50, 100);
        }

        Console.WriteLine("Duel Results:");
        Console.WriteLine($"Human Wins: {humanWins}");
        Console.WriteLine($"Balrog Wins: {balrogWins}");
        Console.WriteLine($"Ties: {ties}");
    }

    
}



class Creature
{
    public string Name { get; }
    public int Strength { get; }
    public int HitPoints { get; private set; }
    public bool IsAlive => HitPoints > 0;

    public Creature(string name, int strength, int hitPoints)
    {
        Name = name;
        Strength = strength;
        HitPoints = hitPoints;
    }

}
