using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour {
    public Text playername;
    public Text score;
    
    public AddScore add;
    // Use this for initialization
    void Start () {
        playername.text = PlayerPrefs.GetString("name");
    }
	
	// Update is called once per frame
	void Update () {
        
        score.text = Convert.ToString(add.score);
        //Debug.Log(playerscore);
    }
}
