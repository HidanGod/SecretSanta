using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ApprovalTests.Reporters;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using static ApprovalTests.Approvals;


namespace SecretSanta
{

    [TestFixture]
    class SecretSanta_Tests
    {
        private SecretSantaDictionary _secretSantaDictionaryGood;
        private string[] participantsGood;
        private SecretSantaDictionary _secretSantaDictionaryBad;
        private string[] participantsBad;
        private HashSet<int> randomNumSant;
        private Random randomNum;

        [SetUp]
        public void SetUp()
        {
            participantsGood = new string[2] {"1", "2"};
            _secretSantaDictionaryGood = new SecretSantaDictionary(participantsGood);
            participantsBad = new string[2] { "1", "1" };
            _secretSantaDictionaryBad = new SecretSantaDictionary(participantsBad);
            randomNumSant = new HashSet<int>();
            randomNum = new Random();
        }


        [Test]
        public void GetSecretSantaFor_Null()
        {
            Assert.Throws<NullReferenceException>(() => _secretSantaDictionaryGood.GetBestowedFor(null));
        }

        [Test]
        public void GetBestowedFor_1()
        {
            _secretSantaDictionaryGood.GetBestowedFor("1").Should().Be("2");
        }

        [Test]
        public void GetBestowedFor_NoSecretSanta()
        {
            _secretSantaDictionaryGood.GetBestowedFor("3").Should().Be("Секретный санта не найден...");
        }

        [Test]
        public void GenerateRandomNumSant_Count()
        {
            GeneratorRandomSant.GenerateRandomNumsSant(participantsGood.Length).Length.Should().Be(2);
        }

        [Test]
        public void GenerateRandomNumSant_Value()
        {
            var result = GeneratorRandomSant.GenerateRandomNumsSant(participantsGood.Length);
            var testHashSet = new HashSet<int>();
            testHashSet.Add(1);
            testHashSet.Add(0);
            Assert.AreEqual(testHashSet, result);
        }

        [Test]
        public void GenerateRandomNumSant_ManyValue()
        {
            participantsGood = new string[4] { "1", "2", "3", "4"};
            _secretSantaDictionaryGood = new SecretSantaDictionary(participantsGood);
            for (int i = 0; i < 1000; i++)
            {
                GeneratorRandomSant.GenerateRandomNumsSant(participantsGood.Length).Length.Should().Be(participantsGood.Length);
            }
        }


        [Test]
        public void CreateListSecretSant_Count()
        {
            _secretSantaDictionaryGood.CreateListSecretSant().Count.Should().Be(2);
        }

        [Test]
        public void CreateListSecretSant_ForBadSecretSanta()
        {
            var ex = new ArgumentException("\"1\" имя было не уникально");
            //Assert.Throws<ArgumentNullException>(() => _secretSantaDictionaryBad.CreateListSecretSant());
        }

        [Test]
        public void CreateListSecretSant_Value()
        {
            var result = _secretSantaDictionaryGood.CreateListSecretSant();
            var testDictionary = new Dictionary<string, string>();
            testDictionary.Add("1","2");
            testDictionary.Add("2","1");
            Assert.AreEqual(testDictionary, result);
        }

        [Test]
        public void CreateListSecretSant__participantsIsNull()
        {
            string[] participants = new string[0];
            SecretSantaDictionary secretSantaDictionary = new SecretSantaDictionary(participants);
            secretSantaDictionary.CreateListSecretSant().Should().BeEmpty();
        }

        [Test]
        public void GenerateRandomNumSant__participantsIsNull()
        {
            string[] participants = new string[0];
            SecretSantaDictionary secretSantaDictionary = new SecretSantaDictionary(participants);
            GeneratorRandomSant.GenerateRandomNumsSant(participants.Length).Should().BeEmpty();
        }

    }

}
