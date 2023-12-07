namespace FantasyRPG.Model
{
    public class RPGCreature
    {
        /// <summary>
        /// 0 = Human, 1 = Demon, 2 = Balrog, 3 = Elf
        /// </summary>
        public int Type { get; set; }
        public int Strength { get; set; }
        public int HitPoints { get; set; }
        
        public string Race
        {
            get
            {
                return Type switch
                {
                    0 => "Human",
                    1 => "Cyberdemon",
                    2 => "Balrog",
                    3 => "Elf",
                    _ => "Unknown",
                };
            }
        }

        public int InflictDamage()
        {
            throw new NotImplementedException();
        }
    }
}

namespace FantasyRPG.Model
{
    public class IRandom
    {

        public object Generator(int v);

        public int Next(object maxValue)
        {
            throw new NotImplementedException();
        }
    }
}

namespace FantasyRPG.Model
{
    public class Battle
    {
        public static string Messages { get; set; }

        public static int Duel(RPGCreature creature1, RPGCreature creature2)
        {
            throw new NotImplementedException();
        }
    }
}