using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {
	public float reload = 2f;
	public GameObject PrefabAmmo = null;
	private bool WeaponsActivated = true;
	private int enemycount = 1;
    public AddScore score;
    public Createboss createboss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (WeaponsActivated&&!createboss.BossExist) {
            int tempx = Random.Range(-25, 25);
            int tempy = Random.Range(10, 50);
            Vector3 position = new Vector3 (tempx/10.0f,tempy/10.0f,0);
			Instantiate (PrefabAmmo, position, PrefabAmmo.transform.rotation);
			enemycount++;
			WeaponsActivated = false;
			Invoke ("ActivateWeapons", reload);
		}

	}
	void ActivateWeapons(){
		WeaponsActivated = true;
	}
}
