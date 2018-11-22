using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta
{
    class MenuServise
    {
        static public int GeParticipantsCount()
        {
            int participantsCount;
            Console.WriteLine("Введите количество участников");
            string textFromConsole = Console.ReadLine();
            if (Int32.TryParse(textFromConsole, out participantsCount))
            {
                return int.Parse(textFromConsole);
            }
            Console.WriteLine("количество участников должно быть числом больше нуля");
            return participantsCount = GeParticipantsCount();
        }

        static public void callGetBestowedFor(SecretSanta secretSanta)
        {
            Console.WriteLine("Что бы узнать имя своего одариваемого введите сове УНИКАЛЬНОЕ имя");
            var cecretSanta = Console.ReadLine();
            Console.WriteLine("Ваш одариваемый это: {0}", secretSanta.GetBestowedFor(cecretSanta));
            Console.WriteLine("Назвать имя одариваемого для следующего участника? (Д/Н)");
            var yesNo = Console.ReadLine();
            if (yesNo == "Д" || yesNo == "д" || yesNo == "l" || yesNo == "L") callGetBestowedFor(secretSanta);
        }

        static public string[] CreateParticipants(int participantsCount)
        {
            var participants = new string[participantsCount];
            for (int i = 0; i < participantsCount; i++)
            {
                Console.WriteLine("введите УНИКАЛЬНОЕ имя {0} участника", (i + 1));
                participants[i] = Console.ReadLine();
            }

            //int i = 0;
            //while (participantsCount < i)
            //{

            //        Console.WriteLine("введите УНИКАЛЬНОЕ имя {0} участника", (i + 1));
            //    participants[i] = Console.ReadLine();
            //    i++;
            //}
            return participants;
        }


    }
}
