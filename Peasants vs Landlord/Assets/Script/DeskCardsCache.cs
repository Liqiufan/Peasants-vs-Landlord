using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCardsCache{

    private static DeskCardsCache instance;

    private List<Card> library;

    private DataType.CharacterType cType;

    private DataType.CardsType rule;

    private DeskCardsCache()
    {
        library = new List<Card>();
        cType = DataType.CharacterType.Desk;
        rule = DataType.CardsType.None;
    }

    public static DeskCardsCache Instance
    {
        get
        {
            if (instance == null)
                instance = new DeskCardsCache();
            return instance;
        }
    }

    public DataType.CardsType Rule
    {
        set { rule = value; }
        get { return rule; }
    }

    /// <summary>
    /// Create an index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Card this[int index]
    {
        get { return library[index]; }
    }

    /// <summary>
    /// Get the cards' count of library.
    /// </summary>
    public int CardCount
    {
        get { return library.Count; }
    }

    /// <summary>
    /// Get the cards' minimum point.
    /// </summary>
    public int MinPoint
    {
        get { return (int)library[0].GetCardPoint; }
    }

    /// <summary>
    /// Get the cards' maximum point.
    /// </summary>
    public int MaxPoint
    {
        get { return (int)library[0].GetCardPoint; }
    }

    public Card Deal()
    {
        Card ret = library[library.Count - 1];

        library.Remove(ret);

        return ret;
    }

    public void AddCard(Card card)
    {
        card.GetAttribution = cType;

        library.Add(card);
    }

    public void Clear()
    {
        if (library.Count != 0)
        {
            CardSprite[] cardSprites = GameObject.Find("Desk").GetComponentsInChildren<CardSprite>();
            for(int i = 0; i < cardSprites.Length; i++)
            {
                cardSprites[i].transform.parent = null;
                cardSprites[i].Destroy();
            }

            while(library.Count != 0)
            {
                Card card = library[library.Count - 1];
                library.Remove(card);
                Deck.Instance.AddCard(card);
            }
        }
    }

    public void Sort()
    {
        CardRules.SortCards(library, true);
    }
}
