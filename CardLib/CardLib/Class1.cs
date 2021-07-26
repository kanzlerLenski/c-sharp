using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    //Куда перечисления и зачем они вообще, если в качестве параметров в конструкторе используем поля, но полям никак не передаём то, что содержится в перечислениях?

    public enum Suit {Clubs, Diamonds, Hearts, Spades}
    public enum Rank {Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}

    public class Card

    {
        public readonly Suit suit;
        public readonly Rank rank;

        public override string ToString()

        {
            return string.Format("{0} {1}.", (Rank)rank, (Suit)suit).ToString(); //Возможно, "base" нужно изменить. Написать строку, которая будет выдавать информаацию о карте.
        }

        //Это конструктор – создаёт объект типа Card с двумя параметрами: Suit и Rank.
        public Card (Suit suit, Rank rank)

        {
            this.suit = suit;
            this.rank = rank;   
        }

       
        public static bool operator > (Card cardOne, Card cardTwo)
        {
            if (cardOne.rank > cardTwo.rank)
                return true;
            else return false;
        }

        public static bool operator  < (Card cardOne, Card cardTwo)
        {
            if (cardOne.rank < cardTwo.rank)
                return true;
            else return false;
        }

         public static bool operator == (Card cardOne, Card cardTwo)
         {
             if (cardOne.rank == cardTwo.rank)
                return true;
            else return false;
         }

         public static bool operator != (Card cardOne, Card cardTwo)
         {
             if (cardOne.rank == cardTwo.rank)
                 return true;
             else return false;
         }


        
    }
}
