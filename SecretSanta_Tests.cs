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
        private SecretSanta _secretSanta;
        private string[] participants;
        private HashSet<int> randomNumSant;
        private Random randomNum;

        [SetUp]
        public void SetUp()
        {
            participants = new string[2] {"1", "2"};
            _secretSanta = new SecretSanta(participants);
            randomNumSant = new HashSet<int>();
            randomNum = new Random();
        }


        [Test]
        public void GetSecretSantaFor_Null()
        {
           
           _secretSanta.GetBestowedFor(null).Should().BeNull();
        }

        [Test]
        public void GetBestowedFor_1()
        {
            _secretSanta.GetBestowedFor("1").Should().Be("2");
        }

        [Test]
        public void GetBestowedFor_NoSecretSanta()
        {
            _secretSanta.GetBestowedFor("3").Should().Be("Секретный санта не найден...");
        }

        [Test]
        public void GenerateRandomNumSant_Count()
        {
            _secretSanta.GenerateRandomNumsSant(randomNumSant, randomNum, participants.Length).Count.Should().Be(2);
        }

        [Test]
        public void GenerateRandomNumSant_Value()
        {
            var result = _secretSanta.GenerateRandomNumsSant(randomNumSant, randomNum, participants.Length);
            var testHashSet = new HashSet<int>();
            testHashSet.Add(1);
            testHashSet.Add(0);
            Assert.AreEqual(testHashSet, result);
        }

        [Test]
        public void CreateListSecretSant_Count()
        {
            _secretSanta.CreateListSecretSant().Count.Should().Be(2);
        }

        [Test]
        public void CreateListSecretSant_Value()
        {
            var result = _secretSanta.CreateListSecretSant();
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
            secretSanta.GenerateRandomNumsSant(randomNumSant, randomNum, participants.Length).Should().BeEmpty();
        }

    }

}
