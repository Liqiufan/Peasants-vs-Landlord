using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform playerCards;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// PlayCard when the player click the button "出牌"
    /// </summary>
    public void PlayCard()
    {
        Destroy(playerCards.GetChild(0).gameObject);
        JudgeWinner(playerCards.childCount);
    }

    /// <summary>
    /// Judge the player is winner or not
    /// </summary>
    /// <param name="remainCards">Player's remains cards count</param>
    private void JudgeWinner(int remainCards)
    {
        if(remainCards == 1)
        {
            Debug.Log("Player win the term!");
        }
    }
}
