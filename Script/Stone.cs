using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    public Vector3 Direction = Vector3.down;
    public float speed = 1.0f;
    public float lifetime = 3.0f;
    public int hp = 20;
    public GameObject addscore;
    public GameObject PrefabBoom = null;
    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        addscore = GameObject.Find("Score");

    }
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
        hp--;
        if (other.tag == "Player")
        {
            hp = 0;
            //Debug.Log(other.tag);
        }
        if (hp <= 0)
        {
            Instantiate(PrefabBoom, transform.position, transform.rotation);
            Destroy(gameObject);
            addscore.GetComponent<AddScore>().score += 5;
        }
    }
}
