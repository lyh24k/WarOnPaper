using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {
	public Slider HPStrip;
	public Playercontroller playerhp;
    public Text curhp;
    public Text Maxhp;

	// Use this for initialization
	void Start () {

		HPStrip.value = HPStrip.maxValue = playerhp.health;
        Maxhp.text = Convert.ToString(HPStrip.maxValue);
        curhp.text = Convert.ToString(HPStrip.value);
	}
	
	// Update is called once per frame
	void Update () {
		HPStrip.value = playerhp.health;
        curhp.text = Convert.ToString(HPStrip.value);
        //Debug.Log (HPStrip.value);
    }
}
