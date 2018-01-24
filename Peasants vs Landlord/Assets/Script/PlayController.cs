using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public delegate void CardEventHandler(bool arg);
public class PlayController
{
    private DataType.CharacterType biggest;     //The biggest card point currently.

    private DataType.CharacterType currentPlayer;

    public event CardEventHandler smartCard;    //Computers play cards.

    public event CardEventHandler activeButton;     //Set the button active.

    private static PlayController instance;

    private PlayController()
    {
        currentPlayer = DataType.CharacterType.Desk;
    }

    public static PlayController Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayController();
            return instance;
        }
    }

    public DataType.CharacterType Type
    {
        get { return currentPlayer; }
    }

    public DataType.CharacterType Biggest
    {
        set { biggest = value; }
        get { return biggest; }
    }

    public void Init(DataType.CharacterType type)
    {
        currentPlayer = type;

        Biggest = type;
        if (currentPlayer == DataType.CharacterType.Player)
        {
            activeButton(false);
        }
        else
        {
            smartCard(true);
        }
    }

    /// <summary>
    /// Play cards in turn.
    /// </summary>
    public void Turn()
    {
        currentPlayer += 1;
        if (currentPlayer == DataType.CharacterType.Desk)
        {
            currentPlayer = DataType.CharacterType.Player;
        }

        if (currentPlayer == DataType.CharacterType.ComputerOne || currentPlayer == DataType.CharacterType.ComputerTwo)
        {
            smartCard(biggest == currentPlayer);
        }
        else if (currentPlayer == DataType.CharacterType.Player)
        {
            activeButton(biggest != currentPlayer);
        }
    }

    public void ResetButton()
    {
        activeButton = null;
    }

    public void ResetSmartCard()
    {
        smartCard = null;
    }
}
