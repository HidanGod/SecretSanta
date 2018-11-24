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
        private SecretSanta _secretSantaGood;
        private string[] participantsGood;
        private SecretSanta _secretSantaBad;
        private string[] participantsBad;
        private HashSet<int> randomNumSant;
        private Random randomNum;

        [SetUp]
        public void SetUp()
        {
            participantsGood = new string[2] {"1", "2"};
            _secretSantaGood = new SecretSanta(participantsGood);
            participantsBad = new string[2] { "1", "1" };
            _secretSantaBad = new SecretSanta(participantsBad);
            randomNumSant = new HashSet<int>();
            randomNum = new Random();
        }


        [Test]
        public void GetSecretSantaFor_Null()
        {
            Assert.Throws<NullReferenceException>(() => _secretSantaGood.GetBestowedFor(null));
        }

        [Test]
        public void GetBestowedFor_1()
        {
            _secretSantaGood.GetBestowedFor("1").Should().Be("2");
        }

        [Test]
        public void GetBestowedFor_NoSecretSanta()
        {
            _secretSantaGood.GetBestowedFor("3").Should().Be("Секретный санта не найден...");
        }

        [Test]
        public void GenerateRandomNumSant_Count()
        {
            _secretSantaGood.GenerateRandomNumsSant(participantsGood.Length).Length.Should().Be(2);
        }

        [Test]
        public void GenerateRandomNumSant_Value()
        {
            var result = _secretSantaGood.GenerateRandomNumsSant(participantsGood.Length);
            var testHashSet = new HashSet<int>();
            testHashSet.Add(1);
            testHashSet.Add(0);
            Assert.AreEqual(testHashSet, result);
        }

        [Test]
        public void GenerateRandomNumSant_ManyValue()
        {
            participantsGood = new string[4] { "1", "2", "3", "4"};
            _secretSantaGood = new SecretSanta(participantsGood);
            for (int i = 0; i < 1000; i++)
            {
                _secretSantaGood.GenerateRandomNumsSant(participantsGood.Length).Length.Should().Be(participantsGood.Length);
            }
        }


        [Test]
        public void CreateListSecretSant_Count()
        {
            _secretSantaGood.CreateListSecretSant().Count.Should().Be(2);
        }

        [Test]
        public void CreateListSecretSant_ForBadSecretSanta()
        {
            var ex = new ArgumentException("\"1\" имя было не уникально");
            //Assert.Throws<ArgumentNullException>(() => _secretSantaBad.CreateListSecretSant());
        }

        [Test]
        public void CreateListSecretSant_Value()
        {
            var result = _secretSantaGood.CreateListSecretSant();
            var testDictionary = new Dictionary<string, string>();
            testDictionary.Add("1","2");
            testDictionary.Add("2","1");
            Assert.AreEqual(testDictionary, result);
        }

        [Test]
        public void CreateListSecretSant__participantsIsNull()
        {
            string[] participants = new string[0];
            SecretSanta secretSanta = new SecretSanta(participants);
            secretSanta.CreateListSecretSant().Should().BeEmpty();
        }

        [Test]
        public void GenerateRandomNumSant__participantsIsNull()
        {
            string[] participants = new string[0];
            SecretSanta secretSanta = new SecretSanta(participants);
            secretSanta.GenerateRandomNumsSant(participants.Length).Should().BeEmpty();
        }

    }

}
