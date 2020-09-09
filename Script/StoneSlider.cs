using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneSlider : MonoBehaviour {

    public Slider HPStrip;
    public Stone stonehp;

    // Use this for initialization
    void Start()
    {

        HPStrip.value = HPStrip.maxValue = stonehp.hp;
    }

    // Update is called once per frame
    void Update()
    {
        HPStrip.value = stonehp.hp;
        //Debug.Log (HPStrip.value);
    }
}
