using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour {
    public float bgspeed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * bgspeed);
        if (transform.position.y <= -5.715f)
        {
            transform.position = new Vector3(transform.position.x,5.0f,transform.position.z);
        }
	}
}
