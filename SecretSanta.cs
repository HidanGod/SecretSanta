using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SecretSanta
{
    public class SecretSanta
    {
        private readonly string[] _participants;
        private readonly Dictionary<string, string> _listSecretSant;

        public SecretSanta(string[] participants)
        {
            _participants = participants;
            _listSecretSant = CreateListSecretSant();
        }

        public SecretSanta()
        {
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
            var randomNumsSant = GenerateRandomNumsSant(_participants.Length);
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

        public int[] GenerateRandomNumsSant(int count)
        {
          
            var generateRandomNumsSant = new int[count];
            if (count == 1) return generateRandomNumsSant;
            var permutation = Enumerable.Range(0, count).ToList();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var num = random.Next(permutation.Count);
                while (permutation[num] == i)
                {
                    num = random.Next(permutation.Count);
                }
                generateRandomNumsSant[i] = permutation[num];
                permutation.Remove(num);
            }

            return generateRandomNumsSant;
        }
    }
}
