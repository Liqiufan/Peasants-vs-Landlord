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

    /// <summary>
    /// The play cards is boom or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsBoom(Card[] cards)
    {
        if (cards.Length != 4)
            return false;

        if (cards[0].GetCardPoint != cards[1].GetCardPoint)
            return false;
        if (cards[1].GetCardPoint != cards[2].GetCardPoint)
            return false;
        if (cards[2].GetCardPoint != cards[3].GetCardPoint)
            return false;

        return true;
    }

    /// <summary>
    /// The play cards is joker boom or not.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsJokerBoom(Card[] cards)
    {
        if (cards.Length != 2)
            return false;

        if (cards[0].GetCardPoint != DataType.Point.SJoker)
            return false;
        if (cards[1].GetCardPoint != DataType.Point.LJoker)
            return false;

        return true;
    }


    public static bool PopEnable(Card[] cards,out DataType.CardsType type)
    {
        type = DataType.CardsType.None;
        bool isRule = false;

        switch (cards.Length)
        {
            case 1:
                isRule = true;
                type = DataType.CardsType.Single;
                break;
            case 2:
                if (IsDouble(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Double;
                }
                else if (IsJokerBoom(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.JokerBoom;
                }
                break;
            case 3:
                if (IsOnlyThree(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }
                break;
            case 4:
                if (IsBoom(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Boom;
                }
                else if (IsThreeAndOne(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.ThreeAndOne;
                }
                break;
            case 5:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }
                else if (IsThreeAndTwo(cards)){
                    isRule = true;
                    type = DataType.CardsType.ThreeAndTwo;
                }
                break;
            case 6:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }else if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.TripleStraight;
                }else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            case 7:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }
                break;
            case 8:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            case 9:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }else if (IsOnlyThree(cards))       //something wrong
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }
                break;
            case 10:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            case 11:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }
                break;
            case 12:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.Straight;
                }else if (IsOnlyThree(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }
                break;
            case 13:
                break;
            case 14:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            case 15:
                if (IsOnlyThree(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }
                break;
            case 16:
                if(IsDoubleStraight(cards)){
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            case 17:
                break;
            case 18:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }else if (IsOnlyThree(cards))
                {
                    isRule = true;
                    type = DataType.CardsType.OnlyThree;
                }
                break;
            case 19:
                break;
            case 20:
                if (IsDoubleStraight(cards)){
                    isRule = true;
                    type = DataType.CardsType.DoubleStraight;
                }
                break;
            default:
                break;
        }

        return isRule;
    }
}
