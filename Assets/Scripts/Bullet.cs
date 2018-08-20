using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {
        transform.Translate(0, 0, speed);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
