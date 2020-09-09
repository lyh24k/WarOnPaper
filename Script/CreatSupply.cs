using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSupply : MonoBehaviour {

    public float reload = 2f;
    public GameObject PrefabAmmo = null;
    private bool WeaponsActivated = false;
    public Createboss createboss;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ActivateWeapons", 5, reload);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (WeaponsActivated && !createboss.BossExist)
        {
            int temp = Random.Range(-25, 25);
            
            Vector3 position = new Vector3(temp/10.0f, 7.0f, 0);
            //Debug.Log(position);
            Instantiate(PrefabAmmo, position, PrefabAmmo.transform.rotation);
            WeaponsActivated = false;
        }

    }
    void ActivateWeapons()
    {
        WeaponsActivated = true;
    }
}
