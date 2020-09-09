using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public Vector3 Direction = Vector3.down;
    //public float speed = 1.5f;
    //public float lifetime = 3.0f;
    public int hp = 100;
    public float reload = 0.1f;
    //public GameObject PrefabAmmo = null;
    public GameObject PrefabAmmoleft = null;
    public GameObject PrefabAmmoright = null;
    //public GameObject GunPosition = null;
    public GameObject GunPositionleft = null;
    public GameObject GunPositionright = null;
    private bool bulletActivated = true;
    public GameObject addscore;
    public GameObject bossexist;
    public GameObject PrefabBoom = null;
    // public bool Bossexist=false;
    // Use this for initialization

    void Start()
    {
        addscore = GameObject.Find("Score");
        bossexist = GameObject.Find("new_Boss");
        hp = addscore.GetComponent<AddScore>().boss * 50 + hp;
        //Debug.Log(hp);

    }
    // Update is called once per frame
    void Update()
    {
        //DestroyMe();
        if (transform.position.y > 3.2)
            transform.position += Direction * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        hp--;
        if (other.tag == "Player")
        {
            hp -= 10;
            //Debug.Log(other.tag);
        }
        if (hp <= 0)
        {
            Instantiate(PrefabBoom, transform.position, transform.rotation);
            Destroy(gameObject);
            addscore.GetComponent<AddScore>().score += 100;
            addscore.GetComponent<AddScore>().boss++;
            bossexist.GetComponent<Createboss>().BossExist = false;
            //addscore.GetComponent<AddScore>().boss++;
        }
    }
    
    private void LateUpdate()
    {
        if (bulletActivated)
        {
            
            Instantiate(PrefabAmmoleft, GunPositionleft.transform.position, PrefabAmmoleft.transform.rotation);
            Instantiate(PrefabAmmoright, GunPositionright.transform.position, PrefabAmmoright.transform.rotation);
            bulletActivated = false;
            Invoke("ActivateWeapons", reload);
        }
    }
    void ActivateWeapons()
    {
        bulletActivated = true;
    }
}
