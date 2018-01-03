using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //private bool landlord = false;
    private int landlordIndex;
    private UISprite landlord;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("UI Root/Player02").GetComponent<UISprite>().spriteName = "Character_Landlord";
        }
	}
}
