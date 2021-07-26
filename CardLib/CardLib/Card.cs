using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class Card
    {
        public readonly Suit suit;
        public readonly Rank rank;

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override string ToString()
        {
            return suit.ToString() + rank.ToString();
                
        }

    }

    public class Deck
    {
      
        public Deck()
        { 
        }
        объявить массив кардс из 52 объектов типа сард и, пройдя в цикле по всем мастям и значениям карт, создать карту с данной мстью и величений с помощью конструктура и записать в ячейку массива. 
        for i 0-51
        foreach Suit in ? 
        Card newOne;
        newOne.suit = 
        newOne.rank = 

        
}


