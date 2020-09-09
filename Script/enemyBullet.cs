using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

	public Vector3 Direction = Vector3.down;
	public float speed = 3.0f;
	public float lifetime = 5.0f;
	// Use this for initialization
	void Start () {
		Invoke ("DestroyMe", lifetime);
	}

	// Update is called once per frame
	void Update () {
		transform.position += Direction * speed * Time.deltaTime;
	}
	void DestroyMe(){
		Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D other){
		Destroy (gameObject);
	}
}
