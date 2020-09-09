using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public int State=0;
	public float reload = 0.9f;
	public GameObject PrefabAmmo = null;
    public GameObject PrefabBoom = null;
	public GameObject GunPosition = null;
	private bool EnemyActivated = true;
    public GameObject addscore;
	// Use this for initialization
	void Start () {
        addscore = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<=-2.5){
			transform.Translate (Vector3.right * Time.deltaTime);
			State = 0;
		}else if (transform.position.x < 2.5&&State==0) {
			transform.Translate (Vector3.right * Time.deltaTime);
			State = 0;
		}else if(transform.position.x>=2.5)
		{
			transform.Translate (Vector3.left * Time.deltaTime);
			State = 1;
		}
		else if(transform.position.x<2.5&&State==1){
			transform.Translate (Vector3.left * Time.deltaTime);
			State = 1;
			}
	}
	void OnTriggerEnter2D(Collider2D other){
        addscore.GetComponent<AddScore>().score += 10;
        addscore.GetComponent<AddScore>().enemy++;
        Instantiate(PrefabBoom, transform.position,transform.rotation);
        Destroy (gameObject);
	}
	void LateUpdate(){
		if (EnemyActivated) {
			
			Instantiate (PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
			EnemyActivated = false;
			Invoke ("ActivateWeapons", reload);
		}
	}
	void ActivateWeapons(){
		EnemyActivated = true;
	}
}
