using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SecretSanta
{
    class SecretSanta
    {
        private readonly string[] _participants;
        private readonly Dictionary<string, string> _listSecretSant;

        public SecretSanta(string[] participants)
        {
            _participants = participants;
            _listSecretSant = CreateListSecretSant();
        }

        public string GetBestowedFor(string nameSecterSanta)
        {
            if(nameSecterSanta == null) throw new NullReferenceException();
            foreach (var secretSanta in _listSecretSant)
            {
                if (nameSecterSanta == secretSanta.Key) return secretSanta.Value;
            }
            return "Секретный санта не найден...";
        }

        public Dictionary<string, string> CreateListSecretSant()
        {
            if (_participants == null) return new Dictionary<string, string>();
            var randomNumsSant = GenerateRandomNumsSant(new HashSet<int>(), new Random(), _participants.Length);
            var listSecretSant = new Dictionary<string, string>();
            var i = 0;
            foreach (var num in randomNumsSant)
            {
                if (!listSecretSant.ContainsKey(_participants[i]))
                    listSecretSant.Add(_participants[i], _participants[num]);  
                i++;
            }
            return listSecretSant;
        }

        public HashSet<int> GenerateRandomNumsSant(HashSet<int> randomNumsSant, Random randomNum, int count)
        {
            if (_participants == null) return new HashSet<int>();
             var countrandomNumSant = randomNumsSant.Count;
            if (countrandomNumSant == count) return randomNumsSant;
            var num = randomNum.Next(count);
            if (!randomNumsSant.Contains(num) && num != countrandomNumSant) randomNumsSant.Add(num);
            return GenerateRandomNumsSant(randomNumsSant, randomNum, count);
        }
    }
}
