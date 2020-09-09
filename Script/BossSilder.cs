using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSilder : MonoBehaviour {

    public Slider HPStrip;
    public Boss bosshp;

    // Use this for initialization
    void Start()
    {

        HPStrip.value = HPStrip.maxValue = bosshp.hp;
    }

    // Update is called once per frame
    void Update()
    {
        HPStrip.value = bosshp.hp;
        //Debug.Log (HPStrip.value);
    }
}
