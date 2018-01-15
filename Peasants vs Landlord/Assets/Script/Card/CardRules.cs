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

    /// <summary>
    /// The play cards is double straight or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDoubleStraight(Card[] cards)
    {
        if (cards.Length < 6 || cards.Length % 2 != 0)
            return false;

        for(int i = 0; i < cards.Length; i += 2)
        {
            if (cards[i + 1].GetCardPoint != cards[i].GetCardPoint)
                return false;

            if (i < cards.Length - 2)
            {
                if (cards[i + 2].GetCardPoint != cards[i].GetCardPoint + 1)
                    return false;

                if (cards[i].GetCardPoint > DataType.Point.One || cards[i + 2].GetCardPoint > DataType.Point.One)
                    return false;
            }
        }
        return true;
    }

    /// <summary>
    /// The play cards is triple straight or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsTripleStraight(Card[] cards)
    {
        if (cards.Length < 6 || cards.Length % 3 != 0)
            return false;

        for(int i = 0; i < cards.Length; i += 3)
        {
            if (cards[i + 1].GetCardPoint != cards[i].GetCardPoint)
                return false;
            if (cards[i + 2].GetCardPoint != cards[i].GetCardPoint)
                return false;
            if (cards[i + 1].GetCardPoint != cards[i + 2].GetCardPoint)
                return false;

            if (i < cards.Length - 3)
            {
                if (cards[i + 3].GetCardPoint - cards[i].GetCardPoint != 1)
                    return false;

                if (cards[i].GetCardPoint > DataType.Point.One || cards[i + 3].GetCardPoint > DataType.Point.One)
                    return false;
            }
        }
        return true;
    }

    /// <summary>
    /// The play cards is only three or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsOnlyThree(Card[] cards)
    {
        if (cards.Length % 3 != 0)
            return false;

        if (cards[0].GetCardPoint != cards[1].GetCardPoint && cards[0].GetCardPoint != cards[2].GetCardPoint && cards[1].GetCardPoint != cards[2].GetCardPoint)
            return false;

        return true;
    }

    /// <summary>
    /// The play cards is three and one or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndOne(Card[] cards)
    {
        if (cards.Length != 4)
            return false;

        if (cards[0].GetCardPoint == cards[1].GetCardPoint && cards[0].GetCardPoint == cards[2].GetCardPoint)
            return true;
        else if (cards[1].GetCardPoint == cards[2].GetCardPoint && cards[2].GetCardPoint == cards[3].GetCardPoint)
            return true;

        return false;
    }

    /// <summary>
    /// The play cards is three and two or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndTwo(Card[] cards)
    {
        if (cards.Length != 5)
            return false;

        if(cards[0].GetCardPoint==cards[1].GetCardPoint && cards[1].GetCardPoint == cards[2].GetCardPoint)
        {
            if (cards[3].GetCardPoint == cards[4].GetCardPoint)
                return true;
        }else if (cards[2].GetCardPoint == cards[3].GetCardPoint && cards[3].GetCardPoint == cards[4].GetCardPoint)
        {
            if (cards[0].GetCardPoint == cards[1].GetCardPoint)
                return true;
        }

        return false;
    }
}
