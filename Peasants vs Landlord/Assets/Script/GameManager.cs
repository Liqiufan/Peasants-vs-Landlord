using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //private bool landlord = false;
    private int landlordIndex;
    private UISprite landlord;
    private int[] playerCards = { 17, 17, 17 };
	// Use this for initialization
	void Start () {
        landlordIndex = Random.Range(1, 4);
        GameObject.Find("UI Root/Players/Player0" + landlordIndex).GetComponent<UISprite>().spriteName = "Character_Landlord";
        playerCards[landlordIndex - 1] += 3;
        Debug.Log("Player0" + landlordIndex + " is landlord");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
