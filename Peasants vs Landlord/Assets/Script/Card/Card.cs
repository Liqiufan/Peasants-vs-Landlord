using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card
{
    /// <summary>
    /// Card's name
    /// </summary>
    private readonly string cardName;

    private readonly DataType.Point point;

    private readonly DataType.Suit suit;

    private DataType.CharacterType characterType;

    /// <summary>
    ///Is the image a sprite?
    /// </summary>
    private bool makedSprite;

    /// <summary>
    /// Here is the description a Card.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="point"></param>
    /// <param name="suit"></param>
    /// <param name="characterType"></param>
    public Card(string cardName, DataType.Point point, DataType.Suit suit, DataType.CharacterType characterType)
    {
        makedSprite = false;
        this.cardName = cardName;
        this.point = point;
        this.suit = suit;
        this.characterType = characterType;
    }

    /// <summary>
    /// Return name of the card.
    /// </summary>
    public string GetCardName
    {
        get { return cardName; }
    }

    /// <summary>
    /// Return point of the card.
    /// </summary>
    public DataType.Point GetCardPoint
    {
        get { return point; }
    }

    /// <summary>
    /// Return suit of the card.
    /// </summary>
    public DataType.Suit GetCardSuit
    {
        get { return suit; }
    }

    public DataType.CharacterType GetAttribution
    {
        set { characterType = value; }
        get { return characterType; }
    }

    public bool IsSprite
    {
        set { makedSprite = value; }
        get { return makedSprite; }
    }
}
