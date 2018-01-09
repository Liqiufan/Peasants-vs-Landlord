using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cards library, shuffle cards , deal cards.
/// </summary>
public class Deck{

    private static Deck instance;

    /// <summary>
    /// Cards library.
    /// </summary>
    private List<Card> library;

    private DataType.CharacterType cType;

    /// <summary>
    /// Judge the library is null or not.
    /// </summary>
    public static Deck Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Deck();
            }
            return instance;
        }

    }

    /// <summary>
    /// Get the card count in the library.
    /// </summary>
    public int CardCount
    {
        get { return library.Count; }
    }

    /// <summary>
    /// Library's index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Card this[int index]
    {
        get
        {
            return library[index];
        }
    }

    private Deck()
    {
        library = new List<Card>();
        cType = DataType.CharacterType.Library;
        CreateDeck();
    }

    void CreateDeck()
    {
        //Create usual cards.
        for (int suit = 0; suit < 4; suit++)
        {
            for(int value = 0; value < 13; value++)
            {
                DataType.Point p = (DataType.Point)value;
                DataType.Suit s = (DataType.Suit)suit;
                string name = s.ToString() + p.ToString();
                Card card = new Card(name, p, s, cType);
                library.Add(card);
            }
        }

        //Creat&Add joker.
        Card smallJoker = new Card("SJoker", DataType.Point.SJoker, DataType.Suit.None, cType);
        Card largeJoker = new Card("LJoker", DataType.Point.LJoker, DataType.Suit.None, cType);
        library.Add(smallJoker);
        library.Add(largeJoker);
    }

    /// <summary>
    /// Shuffle cards.
    /// </summary>
    public void Shuffle()
    {
        if(CardCount == 54)
        {
            System.Random random = new System.Random();
            List<Card> newList = new List<Card>();
            foreach(Card item in library)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }

            library.Clear();

            foreach(Card item in newList)
            {
                library.Add(item);
            }

            newList.Clear();
        }
    }

    /// <summary>
    /// Deal cards.
    /// </summary>
    /// <returns></returns>
    public Card Deal()
    {
        Card ret = library[library.Count - 1];  //Delete a card after deal one card.
        library.Remove(ret);    //Remove the card had been dealed.
        return ret;
    }

    public void AddCard(Card card)
    {
        card.GetAttribution = cType;
        library.Add(card);
    }
}
