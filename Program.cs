using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int participantsCount = MenuServise.GeParticipantsCount();
            var participants = MenuServise.CreateParticipants(participantsCount);
            SecretSanta secretSanta = new SecretSanta(participants);
            Console.WriteLine("Тайные санты успешно сгенерированны!");
            MenuServise.callGetBestowedFor(secretSanta);
        }
    }
}
