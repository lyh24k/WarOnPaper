using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour {

    public Vector3 Direction = Vector3.down;
    public float speed = 5.0f;
    public float lifetime = 3.0f;
    public GameObject addscore;
    public GameObject PrefabAmmo = null;
    public GameObject PrefabBoom = null;
    public GameObject PrefabHealth = null;
    public GameObject Prefabbullet3 = null;
    public GameObject Prefabdebuff = null;
    public GameObject PrefabScore = null;

    // Use this for initialization
    void Start()
    {
        addscore = GameObject.Find("Score");
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyMe();
        transform.position += Direction * speed * Time.deltaTime;
    }
    void DestroyMe()
    {
        if (transform.position.y <= -4.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        addscore.GetComponent<AddScore>().score += 10;
        addscore.GetComponent<AddScore>().supply++;
        int temp = Random.Range(0,100);
        //Debug.Log(temp);
        if (temp <= 15)
        {
            Instantiate(PrefabAmmo, transform.position, PrefabAmmo.transform.rotation);
        }
        else if (temp <= 30 && temp > 15)
        {
            Instantiate(PrefabHealth, transform.position, PrefabHealth.transform.rotation);
        }
        else if (temp <= 45 && temp > 30)
        {
            Instantiate(Prefabbullet3, transform.position, Prefabbullet3.transform.rotation);
        }
        else if (temp <= 55 && temp > 45)
        {
            Instantiate(Prefabdebuff, transform.position, Prefabdebuff.transform.rotation);
        }
        else if (temp <= 90 && temp > 55)
        {
            Instantiate(PrefabScore, transform.position, PrefabScore.transform.rotation);
        }
        Instantiate(PrefabBoom, transform.position, transform.rotation);
        Destroy(gameObject);
            //Debug.Log(other.tag);
       
    }
}
