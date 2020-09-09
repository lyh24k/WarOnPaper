using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Vector3 Direction = Vector3.up;
	public float speed = 10.0f;
    public AudioClip bullet;
    public GameObject issound;
    //public float lifetime = 2.0f;
    // Use this for initialization
    void Start () {
        //Invoke ("DestroyMe", lifetime);
        issound = GameObject.Find("sound");
        if (issound.GetComponent<PlaySound>().IsSound && PlayerPrefs.GetInt("issound") == 1)
            AudioSource.PlayClipAtPoint(bullet, transform.localPosition, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        DestroyMe();
		transform.position += Direction * speed * Time.deltaTime;
	}
	void DestroyMe(){
        if (transform.position.y >= 5.0f)
        {
            Destroy(gameObject);
        }
	}
	void OnTriggerEnter2D(Collider2D other){
		Destroy (gameObject);
	}
}
