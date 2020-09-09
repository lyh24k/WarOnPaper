using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {
    private float lifetime = 5f;
    public AudioClip boom;
    public GameObject issound;
	// Use this for initialization
	void Start () {
        //boom.Play();
        issound = GameObject.Find("sound");
        if(issound.GetComponent<PlaySound>().IsSound&&PlayerPrefs.GetInt("issound")==1)
            AudioSource.PlayClipAtPoint(boom,transform.localPosition,1f);

        Invoke("DestroyMe", lifetime);
        
    }
	
	// Update is called once per frame
	void Update () {
	}
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
