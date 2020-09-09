using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createforg : MonoBehaviour {

    public float reload = 15f;
    public GameObject PrefabAmmo = null;
    private bool WeaponsActivated = false;
    public Createboss createboss;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ActivateWeapons", 10, reload);
    }

    // Update is called once per frame
    void Update()
    {

        if (WeaponsActivated && !createboss.BossExist)
        {
            int temp1 = Random.Range(-20, -10);
            int temp2 = Random.Range(10, 20);
            Vector3 positionleft = new Vector3(temp1/10.0f, 7.0f, 0);
            Vector3 positionright = new Vector3(temp2/10.0f, 7.0f, 0);

            //Debug.Log(position);
            Instantiate(PrefabAmmo, positionleft, PrefabAmmo.transform.rotation);
            Instantiate(PrefabAmmo, positionright, PrefabAmmo.transform.rotation);
            WeaponsActivated = false;
            //InvokeRepeating("ActivateWeapons", 10, 20);
        }

    }
    void ActivateWeapons()
    {
        WeaponsActivated = true;
    }
}
