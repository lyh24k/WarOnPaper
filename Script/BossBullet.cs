using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    public float speed = 3.0f;
    public float lifetime = 3.0f;
    private int angle;
    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMe", lifetime);
        angle = Random.Range(-200, 200);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(Vector3.left.x * angle/100.0f * speed * Time.deltaTime, Vector3.down.y * speed * Time.deltaTime);
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
