namespace FantasyRPG.UnitTesting
{
    internal interface ICreature
    {
        int Attack(ICreature defender);
        object InflictDamage();
        void TakeDamage(int v);
    }
}