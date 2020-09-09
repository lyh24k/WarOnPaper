using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createboss : MonoBehaviour {

    //public float reload = 20f;
    public GameObject PrefabAmmo = null;
    //private bool bossActivated = true;
    public AddScore addScore;
    public bool BossExist = false;
    // Use this for initialization
    void Start()
    {
        //Invoke("ActivateWeapons", reload);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BossExist&&addScore.score/300>addScore.boss)
        {
            Vector3 position = new Vector3(0, 6.0f, 0);
            Instantiate(PrefabAmmo, position, PrefabAmmo.transform.rotation);
            BossExist = true;
            //bossActivated = false;
        }
 

    }
}
