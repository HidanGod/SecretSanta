using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SecretSanta
{
    public class SecretSantaDictionary
    {
        private readonly string[] _participants;
        private readonly Dictionary<string, string> _listSecretSant;

        public SecretSantaDictionary(string[] participants)
        {
            _participants = participants;
            _listSecretSant = CreateListSecretSant();
        }

        public SecretSantaDictionary()
        {
        }

        public string GetBestowedFor(string nameSecterSanta)
        {
            if(nameSecterSanta == null) throw new NullReferenceException();
            if(_listSecretSant.ContainsKey(nameSecterSanta)) return _listSecretSant[nameSecterSanta];
            return "Секретный санта не найден...";
        }

        public Dictionary<string, string> CreateListSecretSant()
        {
            if (_participants == null) return new Dictionary<string, string>();
            var randomNumsSant = GeneratorRandomSant.GenerateRandomNumsSant(_participants.Length);
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

      
    }
}
