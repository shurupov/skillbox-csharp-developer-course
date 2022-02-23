using System;

namespace task_02_blackjack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Сколько у вас карт");
            uint cardsCount = uint.Parse(Console.ReadLine());
            uint points = 0;
            for (uint i = 0; i < cardsCount; i++)
            {
                Console.WriteLine("Введите номинал карты (J, Q, K, A, 2-10)");
                string card = Console.ReadLine();
                switch (card)
                {
                    case "J" :
                    case "Q" :
                    case "K" :
                        points += 10;
                        break;
                    case "A" :
                        points += 11;
                        break;
                    default:
                        points += uint.Parse(card);
                        break;
                }
            }
            Console.WriteLine($"Вы набрали {points} очков");
        }
    }
}