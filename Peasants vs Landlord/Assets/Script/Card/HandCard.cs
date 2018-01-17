using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandCard : MonoBehaviour
{
    public DataType.CharacterType ctype;
    private List<Card> library;
    private DataType.Identity identity;

    private int multples;

    private int integation;

    // Use this for initialization
    void Start()
    {
        multples = 1;
        identity = DataType.Identity.Peasant;
        library = new List<Card>();
    }

    /// <summary>
    /// The multiple of player.
    /// </summary>
    public int Multples
    {
        set { multples = value; }
        get { return multples; }
    }

    /// <summary>
    /// The integation of player.
    /// </summary>
    public int Integation
    {
        set { integation = value; }
        get { return integation; }
    }

    public int CardsCount
    {
        get { return library.Count; }
    }

    /// <summary>
    /// The identity of palyer.
    /// </summary>
    public DataType.Identity AccessIdentity
    {
        set { identity = value; }
        get { return identity; }
    }

    /// <summary>
    /// Get the cards of player.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Card this[int index]
    {
        get { return library[index]; }
    }

    /// <summary>
    /// Get the index of value.
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public int this[Card card]
    {
        get { return library.IndexOf(card); }
    }

    /// <summary>
    /// Add card to palyer.
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card)
    {
        card.GetAttribution = ctype;
        library.Add(card);
    }

    /// <summary>
    /// Play card from hand.
    /// </summary>
    /// <param name="card"></param>
    public void PopCard(Card card)
    {
        library.Remove(card);
    }

    public void Sort()
    {
        CardRules.SortCards(library, false);
    }
}
