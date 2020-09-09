using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_3_right : MonoBehaviour {

    public float speed = 10.0f;
    // public float lifetime = 5.0f;
    // Use this for initialization
    void Start()
    {
        //Invoke("DestroyMe", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyMe();
        transform.position += new Vector3(Vector3.right.x * 0.2f * speed * Time.deltaTime, Vector3.up.y * speed * Time.deltaTime);
        //transform.position += left * speed * Time.deltaTime;
    }
    void DestroyMe()
    {
        if (transform.position.x >= 3.4 || transform.position.y >= 5)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

    }
}
