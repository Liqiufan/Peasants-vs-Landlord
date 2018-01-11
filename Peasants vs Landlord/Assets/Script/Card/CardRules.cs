using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The rules of play cards.
/// </summary>
public class CardRules{

	public static void SortCards(List<Card> cards,bool ascending)
    {
        cards.Sort(
            (Card a,Card b)=> 
            {
                if (!ascending)
                {
                    return -a.GetCardPoint.CompareTo(b.GetCardPoint) * 2 + a.GetCardSuit.CompareTo(b.GetCardSuit);
                }
                else
                {
                    return a.GetCardPoint.CompareTo(b.GetCardPoint);
                }
            }
            
            );
    }

    /// <summary>
    /// The play cards is double or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDouble(Card[] cards)
    {
        if(cards.Length == 2)
        {
            if (cards[0].GetCardPoint == cards[1].GetCardPoint)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// The play cards is straight or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsStraight(Card[] cards)
    {
        if (cards.Length < 5 || cards.Length > 12)
        {
            return false;
        }

        for (int i = 0; i < cards.Length - 1; i++)
        {
            DataType.Point point = cards[i].GetCardPoint;
            if (cards[i + 1].GetCardPoint - point != 1)
            {
                return false;
            }
            if (point > DataType.Point.One || cards[i + 1].GetCardPoint > DataType.Point.One)
            {
                return false;
            }
        }
        return true;
    }
}
