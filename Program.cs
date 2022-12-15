using System;
using System.Collections.Generic;

namespace GameCard
{
    class Card
    {
        public Values Value { get; private set; }
        public Suits Suit { get; private set; }
        public string Name { get { return $"{Value} of {Suit}"; } }
        public Card(Values value, Suits suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return Name;
        }

    }

    class Program
    {
        private static readonly Random randomCard = new Random();

        public static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
        }

        static Card RandomCards()
        {
            return new Card((Values)randomCard.Next(1, 14), (Suits)randomCard.Next(4));
        }

        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            Console.Write("Write number of cards: ");
            if(int.TryParse(Console.ReadLine(), out int numberOfcards))
            {
                for(int i = 0; i < numberOfcards; i++)
                {
                   cards.Add(RandomCards());
                }
            }
            PrintCards(cards);

            cards.Sort(new CardComparierByValue());
            Console.WriteLine("\n... sorting the cards ...\n");
            PrintCards(cards);
                
           
        }
    }
}
