using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Show the card pic
/// </summary>
public class CardSprite : MonoBehaviour {

    private Card card;
    public UISprite sprite;
    private bool isSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Card Poker
    {
        set
        {
            card = value;
            card.IsSprite = true;
            SetSprite();
        }
        get { return card; }
    }

    /// <summary>
    /// The card is selected or not.
    /// </summary>
    public bool Select
    {
        set { isSelected = value; }
        get { return isSelected; }
    }

    /// <summary>
    /// Set UI show.
    /// </summary>
    private void SetSprite()
    {
        if(card.GetAttribution == DataType.CharacterType.Player || card.GetAttribution == DataType.CharacterType.Desk)
        {
            sprite.spriteName = card.GetCardName;
        }
        else
        {
            sprite.spriteName = "CardBack";
        }
    }

    public void Destroy()
    {
        card.IsSprite = false;
        Destroy(this.gameObject);
    }

    /// <summary>
    /// When player click the card.
    /// </summary>
    public void OnClick()
    {
        if(card.GetAttribution == DataType.CharacterType.Player)
        {
            if (isSelected)
            {
                transform.localPosition -= Vector3.up * 10;
                isSelected = false;
            }
            else
            {
                transform.localPosition += Vector3.up * 10;
                isSelected = true;
            }
        }
    }

    /// <summary>
    /// Set the position of cards.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="index"></param>
    public void GoToPosition(GameObject parent, int index)
    {
        sprite.depth = index;
        if(card.GetAttribution == DataType.CharacterType.Player)    //Player cards' position
        {
            transform.localPosition = parent.transform.Find("CardStartPoint").localPosition + Vector3.right * 25 * index;

            if (isSelected)
            {
                transform.localPosition += Vector3.up * 10;
            }
        }else if(card.GetAttribution == DataType.CharacterType.ComputerOne ||card.GetAttribution == DataType.CharacterType.ComputerTwo)     //Computer cards' position
        {
            transform.localPosition = parent.transform.Find("CardStartPoint").localPosition + Vector3.up * -25 * index;
        }else if(card.GetAttribution == DataType.CharacterType.Desk)    //Cards had been dealed.
        {
            transform.localPosition = parent.transform.Find("PlacePoint").localPosition + Vector3.right * 25 * index;
        }
    }
}
