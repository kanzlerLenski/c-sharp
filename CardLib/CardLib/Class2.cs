using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class Deck

    {
        private Card[] cards = new Card[52];
        private Cards myCards = new Cards();

        public Deck() //Что это? Constructor.
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    cards[13*i+j] = new Card((Suit)i, (Rank)j);
                    
                }
            
        }
            
        }


        public Card GetCard (int i)
        {
            {
                return cards[i];
            }

            //if (i < 0 )
         //throw new System.ArgumentOutOfRangeException();
        }

        public void Shuffle()
        {
            int x;
            Card currentCard;

            Random fullHouse = new Random();
            for (int i = 0; i < 52; i++)
            {
                
                x = fullHouse.Next(0, 52);
                currentCard = cards[i];
                cards[i] = cards[x];
                cards[x] = currentCard;
            }

           
           


        }

    }
}
