using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public bool IsSound;
    public GameObject nosound;
    public AudioSource bgm;
    public AudioSource eatool;
    public AudioSource debuff;
    public AudioSource gameover;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("issound") == 0)
        {
            nosound.SetActive(true);
            bgm.mute = true;
            eatool.mute = true;
            debuff.mute = true;
            gameover.mute = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseDown()
    {
        if (gameObject.name == "sound"&&IsSound)
        {
            IsSound =false;
            nosound.SetActive(true);
            bgm.mute = true;
            eatool.mute = true;
            debuff.mute = true;
            gameover.mute = true;
            PlayerPrefs.SetInt("issound", 0);
        }
        else if(gameObject.name == "sound" && !IsSound)
        {
            IsSound = true;
            nosound.SetActive(false);
            bgm.mute = false;
            eatool.mute = false;
            debuff.mute = false;
            gameover.mute = false;
            PlayerPrefs.SetInt("issound", 1);
        }
    }
}
