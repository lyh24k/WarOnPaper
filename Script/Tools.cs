using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour {

    private int State = 0;
    public float lifetime = 10.0f;
    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMe", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -2.5)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            State = 0;
        }
        else if (transform.position.x < 2.5 && State == 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            State = 0;
        }
        else if (transform.position.x >= 2.5)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            State = 1;
        }
        else if (transform.position.x < 2.5 && State == 1)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            State = 1;
        }
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
