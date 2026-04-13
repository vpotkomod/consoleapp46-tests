using ConsoleApp46;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46.Tests1
{
    [TestClass]
    public class PersonTests
    {
        // Проверяет, что конструктор задаёт корректные значения по умолчанию.
        [TestMethod]
        public void Constructor_DefaultValues_ReturnsExpectedInitialState()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.AreEqual(100, Person.ReturnHp(person));
            Assert.AreEqual(100, Person.ReturnMaxHp(person));
            Assert.AreEqual(0, Person.ReturnCoins(person));
            Assert.AreEqual(0, Person.ReturnTrees(person));
            Assert.AreEqual(1, Person.ReturnStrenght(person));
            Assert.AreEqual(1, Person.ReturnPerception(person));
            Assert.AreEqual(5, Person.ReturnEndurance(person));
            Assert.AreEqual(5, Person.ReturnMaxEndurance(person));
            Assert.AreEqual(1, Person.ReturnCharisma(person));
            Assert.AreEqual(1, Person.ReturnIntelligence(person));
            Assert.AreEqual(1, Person.ReturnAgility(person));
            Assert.AreEqual(1, Person.ReturnLuck(person));
        }

        // Проверяет, что метод GetHp увеличивает здоровье на заданное значение.
        [TestMethod]
        public void GetHp_IncreasesHpByGivenValue()
        {
            // Arrange
            var person = new Person();
            int startHp = Person.ReturnHp(person);

            // Act
            Person.GetHp(person, 25);

            // Assert
            Assert.AreEqual(startHp + 25, Person.ReturnHp(person));
        }

        // Проверяет, что метод GetCoins увеличивает количество денег.
        [TestMethod]
        public void GetCoins_IncreasesCoinsByGivenValue()
        {
            // Arrange
            var person = new Person();
            int startCoins = Person.ReturnCoins(person);

            // Act
            Person.GetCoins(person, 10);

            // Assert
            Assert.AreEqual(startCoins + 10, Person.ReturnCoins(person));
        }

        // Проверяет, что метод GetTrees увеличивает количество дерева.
        [TestMethod]
        public void GetTrees_IncreasesTreesByGivenValue()
        {
            // Arrange
            var person = new Person();
            int startTrees = Person.ReturnTrees(person);

            // Act
            Person.GetTrees(person, 3);

            // Assert
            Assert.AreEqual(startTrees + 3, Person.ReturnTrees(person));
        }

        // Проверяет, что метод GetStrenght увеличивает силу на 1.
        [TestMethod]
        public void GetStrenght_IncreasesStrengthByOne()
        {
            // Arrange
            var person = new Person();
            int startStrength = Person.ReturnStrenght(person);

            // Act
            Person.GetStrenght(person);

            // Assert
            Assert.AreEqual(startStrength + 1, Person.ReturnStrenght(person));
        }

        // Проверяет, что метод SpendEndurance уменьшает выносливость на 1.
        [TestMethod]
        public void SpendEndurance_DecreasesEnduranceByOne()
        {
            // Arrange
            var person = new Person();
            int startEndurance = Person.ReturnEndurance(person);

            // Act
            Person.SpendEndurance(person);

            // Assert
            Assert.AreEqual(startEndurance - 1, Person.ReturnEndurance(person));
        }

        // Проверяет, что бой с врагом уменьшает HP врага с учётом силы героя.
        [TestMethod]
        public void EnemyBattling_DecreasesEnemyHpAccordingToHeroStrength()
        {
            // Arrange
            var hero = new Person();
            var enemy = new Person(100, "Enemy");
            int shot = 10;

            // Act
            Person.EnemyBattling(enemy, hero, shot);

            // Assert
            Assert.AreEqual(90, Person.ReturnHp(enemy));
        }

        // Проверяет, что герой получает урон в бою с учётом уровня мира.
        [TestMethod]
        public void HeroBattling_DecreasesHeroHpAccordingToWorldLevel()
        {
            // Arrange
            var hero = new Person(100, "Hero");
            int shot = 10;
            int levelWorld = 2;

            // Act
            Person.HeroBattling(hero, shot, levelWorld);

            // Assert
            Assert.AreEqual(80, Person.ReturnHp(hero));
        }
    }
}




