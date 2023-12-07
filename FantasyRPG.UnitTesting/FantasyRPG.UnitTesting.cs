using FantasyRPG.Model;
using NSubstitute;
using NUnit.Framework.Internal;
using System.Security.Cryptography;

namespace FantasyRPG.UnitTesting
{
    public class ACreature
    {

        [Test]
        public void ACreatureReportsItsRaceAsUnknown()
        {
            var sut = new Creature();
            Assert.That(sut.Race, Is.EqualTo("Unknown"));
        }

        [Test]  
        public void ACreatureCanInflictABaseDamage() 
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(50).Returns(30);
            Creature sut = new Creature(randomGenerator)
            {
                Strength = 50
            };
            int baseDamage = sut.InflictDamage();
            Assert.That(baseDamage, Is.EqualTo(31));
        }

 

        [Test]
        public void RandomGeneratorGenerateRandomIntegerExceptValuePassedToIt()
        {
            int maxValue = 50;
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(maxValue).Returns(30);
            Assert.That(randomGenerator, Is.LessThan(maxValue));
        }

        [Test]
        public void CreatureHas99PercentofChanceOfTakingDamage() 
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(50); 
            var sut = Substitute.ForPartsOf<Human>();

            int damageTaken = sut.TakeDamage(10);
            Assert.That(damageTaken, Is.EqualTo(10));
            
        }

        [Test]
        public void CreatureHas1PercentofChanceOfNotTakingDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(99);
            var sut = Substitute.ForPartsOf<Human>();
            int damageTaken = sut.TakeDamage(10);
            Assert.That(damageTaken, Is.EqualTo(0));
        }

        [Test]
        public void CreatureCanAttackAnotherCreature()
        {
            var attacker = new Human();
            var defender = new Elf();
            int damageTaken = defender.TakeDamage(attacker.InflictDamage());
            Assert.That(damageTaken, Is.EqualTo(0));
        }

        [Test]
        public void HumanReportsRaceAsHuman()
        {
            var sut = new Human();
            string race = sut.Race;
            Assert.That(race, Is.EqualTo("Human"));
        }

        [Test]
        public void HumanHas10PercentChanceOfInflictingDoubleDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(5);
            RPGCreature human = new RPGCreature();
            int damage = human.InflictDamage();
            Assert.That(2 * ((randomGenerator.Generator(50)) + 1), Is.EqualTo(damage));
        }


        [Test]
        public void DemonReportsItsRaceAsDemon()
        {
            var sut = new Demon();
            string race = sut.Race;
            Assert.That(race, Is.EqualTo("Demon"));
        }

        [Test]
        public void DemonHas25PercentChanceOfInflictingAdditional10PercentDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(20); 
            RPGCreature demon = new RPGCreature();
            int damage = demon.InflictDamage();
            Assert.That(((randomGenerator.Generator(50)) + 1 + 10),Is.EqualTo(damage));
        }

        [Test]
        public void DemonHas75PercentChanceOfInflictingBaseDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(80);
            RPGCreature demon = new RPGCreature();
            int damage = demon.InflictDamage();
            Assert.That(((randomGenerator.Generator(50)) + 1), Is.EqualTo(damage));
        }

        [Test]
        public void BalrogReportsItsRaceAsBalrog()
        {
            var sut = new Balrog();
            string race = sut.Race;
            Assert.That(race, Is.EqualTo("Balrog"));
        }

        [Test]
        public void BalrogCanInflictBaseDamageTwice()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(35);
            RPGCreature Balrog = new RPGCreature();
            int damage = Balrog.InflictDamage();
            Assert.That(2 * ((randomGenerator.Generator(50)) + 1), Is.EqualTo(damage));
        }

    }
}