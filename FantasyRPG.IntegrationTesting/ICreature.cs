namespace FantasyRPG.IntegrationTesting
{
    internal interface ICreature
    {
        int Strength { get; set; }
        int HitPoints { get; set; }

        int Attack(ICreature defender);
    }
}