using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Model
{
    public class Creature
    {
        private readonly Random _random;

        private IRandom randomGenerator;

        public int Strength { get; set; }
        public int HitPoints { get; protected set; }

        public virtual string Race { get => "Unknown"; }

        

        public Creature(int strength)
        {
            Strength = strength;
        }

        public Creature(IRandom randomGenerator)
        {
        }

        public Creature()
        {
        }

        public int InflictDamage()
        {
            int damage;
            damage = _random.Next(Strength) + 1;
         
            return damage;
        }



    }

}
