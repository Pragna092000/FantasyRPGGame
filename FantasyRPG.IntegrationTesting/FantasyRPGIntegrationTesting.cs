using FantasyRPG.Model;
using NSubstitute;
using NUnit.Framework.Constraints;
using System.Security.Cryptography;

namespace FantasyRPG.IntegrationTesting
{
    public class FantasyRPGIntegrationTesting
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void CreatureCanInflictDamage()
        {
            ICreature attacker = new Human();
            ICreature defender = new Human();

            attacker.Strength = 50;
            defender.Strength = 40;
            defender.HitPoints = 100;

            int damageInflicted = attacker.Attack(defender);

            Assert.That(defender.HitPoints, Is.GreaterThanOrEqualTo(0));
            Assert.That(damageInflicted, Is.LessThanOrEqualTo(attacker.Strength));

        }

        [Test]
        public void CreatureHas99PercentofChanceOfTakingDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Next(100).Returns(50);
            var sut = Substitute.ForPartsOf<Human>();
            sut.When(x => x.InflictDamage()).CallOriginal();
            sut.GetType().GetProperty("_random").SetValue(sut, randomGenerator);

            int damageTaken = sut.TakeDamage(10);
            Assert.That(damageTaken, Is.EqualTo(10));
        }

        [Test]
        public void CreatureHas1PercentofChanceOfNotTakingDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Next(100).Returns(99);
            var sut = Substitute.ForPartsOf<Human>();
            sut.When(x => x.InflictDamage()).CallOriginal();
            sut.GetType().GetProperty("_random").SetValue(sut, randomGenerator);

            int damageTaken = sut.TakeDamage(10);
            Assert.That(damageTaken, Is.EqualTo(0));
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
        public void DemonHas25PercentChanceOfInflictingAdditional10PercentDamage()
        {
            IRandom randomGenerator = Substitute.For<IRandom>();
            randomGenerator.Generator(100).Returns(20);
            RPGCreature demon = new RPGCreature();
            int damage = demon.InflictDamage();
            Assert.That(((randomGenerator.Generator(50)) + 1 + 10), Is.EqualTo(damage));
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
        public void BattleShouldReportCreature1WonDuel()
        {
            var creature1 = new RPGCreature { Type = 1, Strength = 50, HitPoints = 100 };
            var creature2 = new RPGCreature { Type = 0, Strength = 30, HitPoints = 70 };
            int result = Battle.Duel(creature1, creature2);
            Assert.That(1, Is.EqualTo(result));
            string resultMessage = Battle.Messages;
            Assert.That(resultMessage, Is.EqualTo("Creature 1 won the duel."));
        }

        [Test]
        public void BattleShouldReportCreature2WonDuel()
        {
            var creature1 = new RPGCreature { Type = 0, Strength = 40, HitPoints = 70 };
            var creature2 = new RPGCreature { Type = 2, Strength = 60, HitPoints = 100 };
            int result = Battle.Duel(creature1, creature2);
            Assert.That(2, Is.EqualTo(result));
            string resultMessage = Battle.Messages;
            Assert.That(resultMessage, Is.EqualTo("Creature 2 won the duel."));
        }

        [Test]
        public void BattleShouldReportATieForDuel()
        {
            var creature1 = new RPGCreature { Type = 0, Strength = 1, HitPoints = 3 };
            var creature2 = new RPGCreature { Type = 2, Strength = 1, HitPoints = 3 };
            int result = Battle.Duel(creature1, creature2);
            Assert.That(0, Is.EqualTo(result));
            string resultMessage = Battle.Messages;
            Assert.That(resultMessage, Is.EqualTo("The duel ended in a tie."));
        }

        [Test]
        public void BattleCanReportDuelsMessage()
        {
            var creature1 = new RPGCreature { Type = 0, Strength = 1, HitPoints = 3 };
            var creature2 = new RPGCreature { Type = 2, Strength = 1, HitPoints = 3 };
            Battle.Duel(creature1, creature2);
            string resultMessages = Battle.Messages;
            string[] messagesArray = resultMessages.Split('\n');
            Assert.That(7,Is.EqualTo(messagesArray.Length));
        }
    }
}