using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();

            Cards FirstPlayer = new Cards();
            Cards SecondPlayer = new Cards();

            for (int i = 0; i < 26; i++)
            {
                FirstPlayer.Add(myDeck.GetCard(i));
            }
                  
            for (int i = 26; i < 52; i++)
            {
                SecondPlayer.Add(myDeck.GetCard(i));
            }

            /*foreach (Card c in FirstPlayer)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();*/

            Card fPCard;
            Card sPcard;

            int d = 0;
            while (d <= 52)
            {
                fPCard = FirstPlayer[0];
                sPcard = SecondPlayer[0];
                d++;
                Console.WriteLine(fPCard.ToString());
                Console.WriteLine(sPcard.ToString());
                Console.ReadKey();

                FirstPlayer.Remove(fPCard);
                SecondPlayer.Remove(sPcard);
                if (fPCard > sPcard)
                {
                    FirstPlayer.Add(fPCard);
                    FirstPlayer.Add(sPcard);
                    Console.WriteLine("The first player takes the cards.");
                    Console.ReadKey();
                    
                }
                if (fPCard < sPcard)
                {
                    SecondPlayer.Add(sPcard);
                    SecondPlayer.Add(fPCard);
                    Console.WriteLine("The second player takes the cards.");
                }
                else
                {
                    Console.WriteLine("Dead heat.");
                }

            }

            /*Console.WriteLine(myDeck.GetCard(0).ToString());
            Console.ReadKey();
             
              myDeck.Shuffle();

            for (int i = 0; i <= 51; i++)
            {
                Console.WriteLine(myDeck.GetCard(i).ToString());
                Console.ReadKey();
            }

            myDeck.GetCard(13);
            myDeck.GetCard(3);
            Console.WriteLine(myDeck.GetCard(13).ToString());
            Console.WriteLine(myDeck.GetCard(3).ToString());
            Console.WriteLine((myDeck.GetCard(13) > myDeck.GetCard(3)).ToString());            
            Console.ReadKey();*/
        }
    }
}
