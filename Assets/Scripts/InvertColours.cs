using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertColours : MonoBehaviour {

    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 300 * Time.deltaTime);



        //a cheat way to make the powerup appear for the video hehehe
        if(Input.GetKeyDown(KeyCode.P)) {
            rend.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            rend.enabled = false;
        }

	}

    //when someone picks up the poweruppppp!
    void IsCollected() {


    }
}
