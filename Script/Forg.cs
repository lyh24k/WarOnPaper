using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Forg : MonoBehaviour {

    public Vector3 Direction = Vector3.down;
    public float speed = 1.5f;
    //public float lifetime = 3.0f;
    public int hp = 10;
    public float reload = 0.1f;
    public GameObject PrefabAmmo = null;
    public GameObject PrefabAmmoleft = null;
    public GameObject PrefabAmmoright = null;
    public GameObject PrefabBoom = null;
    public GameObject GunPosition = null;
    public GameObject GunPositionleft = null;
    public GameObject GunPositionright = null;
    private bool EnemyActivated = true;
    public GameObject addscore;
    private float wavetime = 2f;
    // Use this for initialization

    void Start()
    {
        addscore = GameObject.Find("Score");
        StartCoroutine(CreateWave());

    }
    // Update is called once per frame
    void Update()
    {
        //DestroyMe();
        
        if (transform.position.y>3)
            transform.position += Direction * speed * Time.deltaTime;
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
            addscore.GetComponent<AddScore>().score += 50;
            addscore.GetComponent<AddScore>().forg++;
        }
    }

    //void LateUpdate()
    //{
    //            if (EnemyActivated)
    //            {
                
    //                Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
    //                Instantiate(PrefabAmmoleft, GunPositionleft.transform.position, PrefabAmmo.transform.rotation);
    //                Instantiate(PrefabAmmoright, GunPositionright.transform.position, PrefabAmmo.transform.rotation);
    //                EnemyActivated = false;
    //                Invoke("ActivateWeapons", reload);
    //            }
    //}
    void CreateBullet()
    {
        Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
        Instantiate(PrefabAmmoleft, GunPositionleft.transform.position, PrefabAmmo.transform.rotation);
        Instantiate(PrefabAmmoright, GunPositionright.transform.position, PrefabAmmo.transform.rotation);
    }
    IEnumerator CreateWave()
    {
        while (EnemyActivated)
        {
            for (int i = 0; i < 10; i++)
            {
                CreateBullet();
                yield return new WaitForSeconds(reload);
            }
            EnemyActivated = false;
            yield return new WaitForSeconds(wavetime);
            ActivateWeapons();
        }
    }
    void ActivateWeapons()
    {
        EnemyActivated = true;
    }
}
