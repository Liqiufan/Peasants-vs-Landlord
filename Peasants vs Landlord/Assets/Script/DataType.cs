using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataType{
    /// <summary>
    /// Character
    /// </summary>
    public enum CharacterType
    {
        Library = 0,
        Player,
        ComputerOne,
        ComputerTwo,
        Desk
    }

    /// <summary>
    /// Card's Color
    /// </summary>
    public enum Suit
    {
        Spade,
        Heart,
        Culbs,
        Diamond,
        None
    }

    /// <summary>
    /// Card's point
    /// </summary>
    public enum Point
    {
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        One,
        Two,
        SJoker,
        LJoker,
        None
    }

    /// <summary>
    /// Identity
    /// </summary>
    public enum Identity
    {
        Peasant,
        Landlord
    }

    /// <summary>
    /// Play CardsType
    /// </summary>
    public enum CardsType
    {
        JokerBoom,
        Boom,
        OnlyThree,
        ThreeAndOne,
        ThreeAndTwo,
        Straight,
        DoubleStraight,
        TripleStraight,
        Double,
        Single,
        None
    }
}

/// <summary>
/// Save the data in this game.
/// </summary>
public class GameData
{
    /// <summary>
    /// Player's cards.
    /// </summary>
    public int playerIntegaration;
    /// <summary>
    /// ComputerOne's cards.
    /// </summary>
    public int computerOneIntegaration;
    /// <summary>
    /// ComputerTwo's cards.
    /// </summary>
    public int computerTwoIntegaration;
}