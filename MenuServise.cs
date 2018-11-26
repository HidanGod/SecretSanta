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
            if (Int32.TryParse(textFromConsole, out participantsCount) && int.Parse(textFromConsole)>1)
            {
                return int.Parse(textFromConsole);
            }
            Console.WriteLine("количество участников должно быть числом больше 1");
            return GeParticipantsCount();
        }

        static public void callGetBestowedFor(SecretSantaDictionary secretSantaDictionary)
        {
            Console.Clear();
            Console.WriteLine("Что бы узнать имя своего одариваемого введите сове УНИКАЛЬНОЕ имя");
            var cecretSanta = Console.ReadLine();
            Console.WriteLine("Ваш одариваемый это: {0}", secretSantaDictionary.GetBestowedFor(cecretSanta));
            Console.WriteLine("Назвать имя одариваемого для следующего участника? (Y/N)");
            var yesNo = Console.ReadKey();
            if (yesNo.Key == ConsoleKey.Y) callGetBestowedFor(secretSantaDictionary);
        }

        static public string[] CreateParticipants(int participantsCount)
        {
            var participants = new string[participantsCount];
            for (int i = 0; i < participantsCount; i++)
            {
                Console.WriteLine("введите УНИКАЛЬНОЕ имя {0} участника", (i + 1));
                var participant = Console.ReadLine();
                if (!participants.Contains(participant)) participants[i] = participant;
                else
                {
                    Console.WriteLine("Имя \"{0}\" не  УНИКАЛЬНО!!!", participant);
                    i--;
                }
            }
            return participants;
        }
    }
}
