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
            Console.WriteLine("Количество участников?");
            var participantsCount = Convert.ToInt32(Console.ReadLine());
            var participants = new string[participantsCount];
            for (int i = 0; i < participantsCount; i++)
            {
                Console.WriteLine("введите УНИКАЛЬНОЕ имя {0} участника", (i + 1));
                participants[i] = Console.ReadLine();
            }
            SecretSanta secretSanta = new SecretSanta(participants);
            Console.WriteLine("Тайные санты успешно сгенерированны!");
            Console.WriteLine("Что бы узнать имя своего одариваемого введите сове УНИКАЛЬНОЕ имя");
            var cecretSanta = Console.ReadLine();
            Console.WriteLine("Ваш одариваемый это: {0}",secretSanta.GetBestowedFor(cecretSanta));
            Console.WriteLine("Назвать имя одариваемого для следующего участника? (Д/Н)");
            var yesNo = Console.ReadLine();
            if(yesNo == "Д") 
            Console.Read();

        }




    }
}
