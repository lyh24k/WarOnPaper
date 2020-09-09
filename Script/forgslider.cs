using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forgslider : MonoBehaviour {

    public Slider HPStrip;
    public Forg forghp;

    // Use this for initialization
    void Start()
    {

        HPStrip.value = HPStrip.maxValue = forghp.hp;
    }

    // Update is called once per frame
    void Update()
    {
        HPStrip.value = forghp.hp;
        //Debug.Log (HPStrip.value);
    }
}
