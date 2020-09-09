using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgRight : MonoBehaviour {

    public float speed = 3.0f;
    public float lifetime = 5.0f;
    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMe", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Vector3.right.x * 0.15f * speed * Time.deltaTime, Vector3.down.y * speed * Time.deltaTime);
        //transform.position += left * speed * Time.deltaTime;
    }
    void DestroyMe()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

    }
}
