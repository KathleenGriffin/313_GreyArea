using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 0.0001f;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed, 0, 0);
	}


    //so that we don't end up with 1000 bullets floating round
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
