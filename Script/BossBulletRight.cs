using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletRight : MonoBehaviour {

    public float speed = 3.0f;
    public float lifetime = 5.0f;
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
        
        //Debug.Log(temp);
        transform.position += new Vector3(Vector3.right.x * (angle / 100.0f )* speed * Time.deltaTime, Vector3.down.y * speed * Time.deltaTime);
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
